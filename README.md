# fake-fsharp-demo
A Demo project to show the power of FAKE.Build F#

There is a normal application (Console app) with a Core code library and some unit tests to show how it fits together. 

The build script is sitting under ./Code/demo-build.fsx

To run it: 

```
 mono Tools/FAKE/tools/FAKE.exe Code/demo-build.fsx build -version "1.0" env="prod"
```

This will trigger the following targets:

> Clean
> Prepare (to transform app.config file)
> Build

Obviously, you can give it whatever version and env name and it will transform your app.config for you. 

To run the tests: 

 mono Tools/FAKE/tools/FAKE.exe Code/demo-build.fsx run-tests