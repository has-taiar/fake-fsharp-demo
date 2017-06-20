
#r @"../Tools/FAKE/tools/FakeLib.dll" 

open Fake
open System
open ConfigurationHelper
open Fake.FileHelper

let solutionFile = "Code/Fake.Build.Demo.sln"
let appConfigFilePath = "Code/Fake.Build.Demo/App.Config"
let buildDir = "Code/Fake.Build.Demo/bin"

let version = getBuildParamOrDefault "version" "1.0.0"
let env = getBuildParamOrDefault "env" "dev"

Target "clean" (fun _ -> CleanDir buildDir)


Target "prepare-build" (fun () ->
    Fake.TraceHelper.log ("--------------- Started Preparing the Build ---------------")      
    Fake.TraceHelper.log (String.Format("Preparing the Build for Environment: '{0}' , and Version: '{1}'", env, version))
    updateAppSetting "EnvName" env appConfigFilePath 
    updateAppSetting "Version" version appConfigFilePath
    Fake.TraceHelper.log ("--------------- Finished Preparing the Build ---------------")
)

Target "build" (fun () ->

    RestorePackages()
    MSBuild buildDir "ReBuild" [ ("Configuration", "Debug") ] [ solutionFile ] |> ignore
)

Target "run-tests" (fun _ ->
  !! (buildDir + "/*Tests.dll")
    |> NUnit (fun p -> {p with ToolPath = "Tools/NUnit/NUnit.Runners/tools" })
)

"clean"
  ==> "build"
  ==> "run-tests"

"prepare-build"
  ==> "build"
 

RunTarget() 