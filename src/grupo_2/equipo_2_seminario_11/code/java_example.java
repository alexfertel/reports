import java.lang.reflect.*;

// Tenemos una interfaz IOriginal
interface IOriginal {
    void originalMethod(String s);
}

interface INotOriginal{
    void NotOriginalMethod(String s);
}

// Tenemos una clase Original que implementa la interfaz IOriginal
class Original implements IOriginal {
    public void originalMethod(String s) {
        System.out.println(s);
    }
}
// El Handler
class DynamicInvocationHandler implements InvocationHandler {
    public Object target;
    
    public DynamicInvocationHandler(Object target) {
        this.target = target;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args)
          throws IllegalAccessException, IllegalArgumentException,
          InvocationTargetException {
      if ("originalMethod".equals(method.getName())){
          System.out.println("BEFORE");
          method.invoke(target, args);
          System.out.println("AFTER");
      }
      
      
      return null;
  }
}

public class Main {
    public static void main(String[] args) {
        Original original = new Original();
        DynamicInvocationHandler handler = new DynamicInvocationHandler(original);

        INotOriginal f2 = (INotOriginal) Proxy.newProxyInstance(INotOriginal.class.getClassLoader(),
                new Class[] { INotOriginal.class },
                handler); 
        f2.NotOriginalMethod("Hallo");
    }
}