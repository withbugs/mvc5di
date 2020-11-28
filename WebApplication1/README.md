# この実装には不具合があります。WebApplication2の実装を使用してください。
この実装はScopeの設定ができていないので、AddScoped が AddSingleton と同じ挙動となっている。

## NuGetをインストール
- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/)
- [Microsoft.Owin.Host.SystemWeb](https://www.nuget.org/packages/Microsoft.Owin.Host.SystemWeb)

## Startup.cs
- プロジェクトを右クリック - 追加 - 新しい項目 - OWIN Startup

## 参考
- [Microsoft.Extensions.DependencyInjection を使った DI の基本](https://qiita.com/TsuyoshiUshio@github/items/20412b36fe63f05671c9)
- [OWIN化手順](https://techinfoofmicrosofttech.osscons.jp/index.php?OWIN%E5%8C%96%E6%89%8B%E9%A0%86)
- [Integrating ASP.NET Core Dependency Injection in MVC 4](https://scottdorman.blog/2016/03/17/integrating-asp-net-core-dependency-injection-in-mvc-4/)
- [ASP.NET Core での依存関係の挿入](https://docs.microsoft.com/ja-jp/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-5.0)
