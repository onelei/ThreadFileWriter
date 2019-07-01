# ThreadFileWriter
Unity C# 多线程同时写入一个文件

## 是什么

​		ThreadFileWriter是一个Unity下可以多线程对文件进行写入的框架。



## 为什么

​		当我们在Unity的多线程中要调试一些问题的时候，需要写入文件查看问题在哪。比如网络问题，这个时候在主线程下就无法将信息很好的打印出来。这就诞生了ThreadFileWriter。



## 怎么做

我们都知道多线程下要争夺某项资源需要独占，等访问结束才允许别人多其操作。事实上我们只需要对某个函数进行调用的时候加把锁就好了。我们定义一个volatile变量threadLocker 

```
private volatile object threadLocker = new object();
```

在写文件的时候添加threadLocker即可

![QQ截图20190701201155](https://github.com/onelei/ThreadFileWriter/blob/master/Images/QQ截图20190701201155.png)

同理在读文件，关闭文件总之针对文件操作的地方添加锁即可。



## 示例

打开并运行“ThreadFileWriter.unity”场景，在Console里面看到如下log信息，即表示示例运行成功。

![QQ截图20190701195542](https://github.com/onelei/ThreadFileWriter/blob/master/Images/QQ截图20190701195542.png)

我们在Assets同目录下发现创建了两个文件“Log.txt”和“Test.txt”，里面写入了部分log信息。

![QQ截图20190614202048](https://github.com/onelei/ThreadFileWriter/blob/master/Images/QQ截图20190614202048.png)