import inspect, itertools, sys, os


def check_invariant(instance, inva):
    inva_sig = inspect.signature(inva)

    instance_dict = {}
    inva_params = []
    for attribute, value in instance.oInstance.__dict__.items():
        instance_dict[attribute] = value

    for param in inva_sig.parameters:
        if str(param) in instance_dict.keys():
            inva_params.append(instance_dict[str(param)])
        else:
            raise Exception(
                "pre-condition params not defined in this scorpe")
    try:
        if not inva(*inva_params):
            raise Exception("Invariant statment invalid")
        else:
            pass
    except NameError:
        pass

def contract_invariant(inva):
    def invariant(Cls):
        class NewCls(object):
            def __init__(self, *args, **kwargs):
                self.oInstance = Cls(*args, **kwargs)

                check_invariant(self, inva)

            def __getattribute__(self, s):
                try:
                    if not callable(inva):
                        raise Exception("invariant statement must be callable!!")
                except NameError:
                    pass

                try:
                    x = super(NewCls, self).__getattribute__(s)
                except AttributeError:
                    pass
                else:
                    return x
                x = self.oInstance.__getattribute__(s)
                if type(x) == type(self.__init__):  # it is an instance method
                    check_invariant(self, inva)
                    
                    return x
                else:
                    return x
        return NewCls
    return invariant


def contract(require, ensure):

    try:
        if not callable(require):
            raise Exception("require statement must be callable!!")
        if not callable(ensure):
            raise Exception("ensure statement must be callable!!")
    except NameError:
        pass

    req_sig = inspect.signature(require)
    ens_sig = inspect.signature(ensure)

    def func_wrapper(func):
        def args_wrapper(*args, **kwargs):
            req_params = []
            ens_params = []

            # names and values as a dictionary:
            instance_dict = {}
            args_name = inspect.getfullargspec(func)[0]
            args_dict = dict(itertools.zip_longest(args_name, args))

            for attribute, value in args[0].__dict__.items():
                instance_dict[attribute] = value

            for param in req_sig.parameters:
                if str(param) in args_dict.keys():
                    req_params.append(args_dict[str(param)])
                elif str(param) in instance_dict.keys():
                    req_params.append(instance_dict[str(param)])
                else:
                    raise Exception("pre-condition params not defined in this scorpe")

            for param in ens_sig.parameters:
                if str(param) in args_dict.keys():
                    ens_params.append(args_dict[str(param)])
                elif str(param) in instance_dict.keys():
                    ens_params.append(instance_dict[str(param)])
                else:
                    raise Exception("pos-condition params not defined in this scope")
            
            try:
                if require(*req_params):
                    value = func(*args, **kwargs)

                    try:
                        if ensure(*ens_params):
                            return value
                        else:
                            raise Exception()
                    except Exception as e: 
                        exc_type, exc_obj, exc_tb = sys.exc_info()
                        fname = os.path.split(exc_tb.tb_frame.f_code.co_filename)[1]
                        print(exc_type, fname, exc_tb.tb_lineno)
                        print("pos-conditions fails")
                else:
                    raise Exception()
            except Exception as e:
                exc_type, exc_obj, exc_tb = sys.exc_info()
                fname = os.path.split(exc_tb.tb_frame.f_code.co_filename)[1]
                print(exc_type, fname, exc_tb.tb_lineno)
                print("pre-conditions fails")
        return args_wrapper
    return func_wrapper



@contract_invariant(inva=lambda balance: balance > 0)
class Wallet:

    def __init__(self, balance):
        self.balance = balance

    @contract(require=lambda amount: amount >= 0, ensure=lambda balance: balance >= 0)
    def deposit(self, amount):
        self.balance += amount

    @contract(require=lambda amount, balance: amount >= 0 and amount <= balance, ensure=lambda balance: balance >= 0)
    def withdraw(self, amount):
        self.balance -= amount

    @property
    def check_balance(self):
        print(f"You're current balance is: {self.balance}")


if __name__ == "__main__":
    
    w = Wallet(20)
    w.check_balance
    w.deposit(20)
    w.check_balance
    w.deposit(-20)
    w.check_balance
    w.withdraw(30)
    w.check_balance
    w.withdraw(11)
    w.check_balance

