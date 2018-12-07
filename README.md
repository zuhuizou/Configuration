# Usage

appsettings.json
if the consul key is App1/Server1/Config, then the KeyStoreFolder is App1/Server1

```
{
  "ConsulConfig": {
    "Urls": [ "http://consul.config.com"],
    "KeyStoreFolder": "App1"
  }
}
```

program.cs

```
public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration(context => {
            context.ConsulConfig();
        })
        .UseStartup<Startup>();
```

other is same as local config file
