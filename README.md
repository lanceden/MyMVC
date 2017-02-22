#  Day 3
## MVC，從無到有的建構 ( Hello World! )
1. 新增一個空白專案
2. 使用nuget將MVC package加入到專案中
3. 新增Global.asax
4. 新增路由檔(可由預設專案COPY)
5. 註冊的註冊(到Global.asax.cs 加入
RouteConfig.RegisterRoutes(RouteTable.Routes); =>要加入using 的namespace ) 5. 新增 Controller檔 => 新增controller程式並繼承mvc.controller
6. 新增檢視(View) 不要套用模板，並修改View檔 "Hello World"
7. 加入View/Web config & 調整namespace
 
## 新增ViewEnginesConfig進行MVC優化
1. 新增物件檔，命名為ViewEnginesConfig
2. 要設定物件為Static，並將傳入參數宣告為 : ViewEngineCollection viewEngines 3. 加入code: ViewEngines.Engines.Clear();
        viewEngines.Add(new CSharpRazorViewEngine()); 4. 透過IL.Spy看MVC.dll
5. 找到RazorViewEngine並把整個Function 放到剛剛新增的物件檔，只留存 cshtml的部分
6. 異動Function名字
   public RazorViewEngine(IViewPageActivator viewPageActivator) : base(viewPageActivator) 
   => internal class CSharpRazirViewEngine:RazorViewEngine{}
   => 建立建構子public CSharpRazirViewEngine(){}
     
## Vue Hello World
1. 引用VUE CDN
2. 引用Jquery CDN
3. 引用bootstrap CDN
4. 創建VUE instance
5. 取mock data 至畫面,並使用v-for 將資料呈現在畫面
  
###  Day 3 HomeWork
* 利用VUE實作計算機

#  Day 4
## 自定義ControllerFactory
1. 新增MyControllerFactory
2. 查看MVCSource查看可以複寫Create 方法
3. 複寫Create 方法
4. 依客戶需求自定Controller名稱,如:PersonSKL
5. 一樣是在Create新增判斷即可

## 新增mock data by list
1. 在HomeController中新增一個PersonList,並新增100個資料進List
2. 在View宣告成強類型視圖(@model xxx)
3. 用@foreach 將list資料展示在頁面上

## 自定義擴展方法(Htmlhelper)
1. 查看HtmlHelper可以看到MVC的HTmlTextBox()也是用擴展方法實現,所以我們也可以自定義我們的Helper
2. 建立自己的Helper並實作Html.Button()

###  Day 4 HomeWork
* 利用Find方法完成修改


