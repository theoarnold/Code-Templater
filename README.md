Allows you to insert values into your own custom templates, helping to decrease the time spent on boilerplate code that is similar across a number of classes.

![f97e650ed95d3f7e7609b00ad82750d4](https://github.com/theoarnold/Code-Templater/assets/15271435/8db93e9b-7902-437d-8b08-902e0f58a545)

For example, this template:
```
public class [rep1]()
{
<repList>// <summary>Your comment for [repFU]. </summary>
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
// <summary>Your comment for Test1. </summary>
string Test1Value = "test1";
// <summary>Your comment for Test2. </summary>
string Test2Value = "test2";
// <summary>Your comment for Test3. </summary>
string Test3Value = "test3";
// <summary>Your comment for Test4. </summary>
string Test4Value = "test4";
// <summary>Your comment for Test5. </summary>
string Test5Value = "test5";
// <summary>Your comment for Test6. </summary>
string Test6Value = "test6";
// <summary>Your comment for Test7. </summary>
string Test7Value = "test7";
// <summary>Your comment for Test8. </summary>
string Test8Value = "test8";
// <summary>Your comment for Test9. </summary>
string Test9Value = "test9";

}
```
