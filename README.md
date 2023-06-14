Allows you to insert values into your own custom templates, helping to decrease the time spent on boilerplate code that is similar across a number of classes.

![6368ab18a81d07d827480e559e2f4877](https://github.com/theoarnold/Code-Templater/assets/15271435/387f9126-0159-4a96-b166-8f048eaa0336)

For example, this template:
```
public class [rep1]()
{
<repList>//Your comment for [repFU]. </summary>
string [repFU]Value = "[repFL]";</repList>
}
```
And input these values:
```
(ExampleClass), test1, test2, test3, test4, test5, test6, test7, test8, test9
```
It Becomes this:
```
public class ExampleClass
{
//Your comment for Test1. 
string Test1Value = "test1";
//Your comment for Test2. 
string Test2Value = "test2";
//Your comment for Test3. 
string Test3Value = "test3";
//Your comment for Test4. 
string Test4Value = "test4";
//Your comment for Test5. 
string Test5Value = "test5";
//Your comment for Test6. 
string Test6Value = "test6";
//Your comment for Test7. 
string Test7Value = "test7";
//Your comment for Test8. 
string Test8Value = "test8";
//Your comment for Test9. 
string Test9Value = "test9";

}
```
