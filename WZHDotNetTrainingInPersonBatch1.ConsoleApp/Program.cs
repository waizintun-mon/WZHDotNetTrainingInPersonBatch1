// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using WZHDotNetTrainingInPersonBatch1.ConsoleApp;
//AdoDotNetService adoDotNetService = new AdoDotNetService();
//adoDotNetService.Read();
//adoDotNetService.Create(); 
//adoDotNetService.Update();
//adoDotNetService.Delete();
//DapperService dapperService = new DapperService();
////dapperService.Create();
//dapperService.Update();
//dapperService.Read();
EfCoreModelService efCoreModelService = new EfCoreModelService();
efCoreModelService.Read();
efCoreModelService.Create();
Console.ReadLine();