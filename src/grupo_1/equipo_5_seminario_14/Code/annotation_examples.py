def foo (param0,param1:type, param2:'string',param3:max(1,2,3)='default'\
        ,*args:{1:'1',2:'2'},**kwargs:[1,2,3,4])->str:
        print(foo.__annotations__)
foo(1,2,3)