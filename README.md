# ChatBotSample_SkypeforBiz_AppInsights

Azure Bot FrameworkとQnA Maker Serviceを用いて作成した、Skype for Business用ChatBotのサンプルコード(C#版)です。Application Insightsを用いて、チャットログのトレースを行うことができます。
Visual Studioを用いずに、Azureポータル上の簡単な設定だけでChatBotを動かすことが出来ます。Skype for BusinessではRich Interface(選択ボタンetc)が機能しないため、数字での入力をユーザに促す設定になっています。 ChatBotやApplication Insightsを用いたログ解析のPoCに、お使いいただけます。

# Azure Bot Serviceの作成

1. Azureポータルでリソースの作成から**Web App Bot**をデプロイしてください。この際、ボットテンプレートを選択できますが、**Question and Answer(C#)** をお選びください。

<a href="https://imgur.com/3eyj8uB"><img src="https://i.imgur.com/3eyj8uB.png" title="source: imgur.com" /></a>

2. デプロイが完了したら、Web App Botをお開きください。

3. Web App Botを開いたら、画面左側のリストから**アプリケーション設定**を選択してください。

<a href="https://imgur.com/7HL2hCV"><img src="https://i.imgur.com/7HL2hCV.png" title="source: imgur.com" /></a>

# キーの設定

1. AzureポータルのWeb App Botのアプリケーション設定の以下の欄に、**QnA Makerポータルで発行された3種類のキー** (QnAAuthKey, QnAEndpointHostName, QnAKnowledgebaseId)を貼り付けてください。

<a href="https://imgur.com/fCyBe4z"><img src="https://i.imgur.com/fCyBe4z.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/7ALidSR"><img src="https://i.imgur.com/7ALidSR.png" title="source: imgur.com" /></a>

2. 入力が終わりましたら、画面上部の**保存**をクリックしてください。

# ソースコードの編集

1. App Serviceの画面左側のリストから、**App Service Editor (プレビュー)** を選択して頂き、**移動** をクリックしてください(ブラウザで別ウィンドウが開きます)。

<a href="https://imgur.com/xNjbowM"><img src="https://i.imgur.com/xNjbowM.png" title="source: imgur.com" /></a>

2. App Service Editorの画面にて、画面左側に複数個のフォルダとファイルがあるかと思います。これらを**全て削除**してください(ファイル名上で右クリック→Delete)。

<a href="https://imgur.com/MG1vn0G"><img src="https://i.imgur.com/MG1vn0G.png" title="source: imgur.com" /></a>

3. 変更内容は全て自動で保存されます。すべて削除し終わったら、Azureポータル画面にお戻り下さい。


# デプロイオプション

1. App Serviceの画面左側のリストから**デプロイ オプション**を選択してください。

2. **ソースの選択**から**外部リポジトリ**を選択してください。

<a href="https://imgur.com/FyEg10e"><img src="https://i.imgur.com/FyEg10e.png" title="source: imgur.com" /></a>

3. **リポジトリのURL**に、このリポジトリのURL(<https://github.com/NoriMin/ChatBotSample_SkypeforBiz_AppInsights.git>)をコピー&ペーストして**OK**をクリックしてください。

<a href="https://imgur.com/kOxwKva"><img src="https://i.imgur.com/kOxwKva.png" title="source: imgur.com" /></a>

4. 完了すると、以下のような画面になります。

<a href="https://imgur.com/7Cohg22"><img src="https://i.imgur.com/7Cohg22.png" title="source: imgur.com" /></a>

# Application Insightsとのリンク

1. App Serviceの画面左側のリストから、**Application Insights** を選択して頂き、**変更** をクリックしてください。

<a href="https://imgur.com/kfkTXsn"><img src="https://i.imgur.com/kfkTXsn.png" title="source: imgur.com" /></a>

2. **既存のリソースの選択**でWeb App Botと共にデプロイしたApplication Insightsリソースを選択してください。**アプリケーションのインストゥルメンテーション**でランタイム/フレームワークを**ASP.NET**としてください。Web App Botデプロイ時にApplication Insightsを作成していない場合は、**新しいリソースの作成**を行ってください。

<a href="https://imgur.com/xr0G9Oh"><img src="https://i.imgur.com/xr0G9Oh.png" title="source: imgur.com" /></a>

3. OKをクリックすると、以下のようなポップアップが表示されますが**続行**を選択してください。

<a href="https://imgur.com/RYGTmta"><img src="https://i.imgur.com/RYGTmta.png" title="source: imgur.com" /></a>

# 動作確認

以上で、セットアップは終了です。Web Chatや登録済みのSkype for Businessから動作確認を行ってください。

<a href="https://imgur.com/38pzIM1"><img src="https://i.imgur.com/38pzIM1.png" title="source: imgur.com" /></a>

# Application Insightsを用いたログの確認

1. 設定を行ったApplication Insightsの**概要**タブから**分析**を選択してください。

<a href="https://imgur.com/vQtT6sV"><img src="https://i.imgur.com/vQtT6sV.png" title="source: imgur.com" /></a>

2. 画面上部の空欄にクエリを入力します。クエリの詳細については、**以下のリンク**をご参照ください。
   (<https://github.com/NoriMin/AppInsightsQuery-TraceLogs/blob/master/README.md>)

<a href="https://imgur.com/bDJL75E"><img src="https://i.imgur.com/bDJL75E.png" title="source: imgur.com" /></a>

3. クエリ作成後、**RUN**を押すと結果を見ることが出来ます。

<a href="https://imgur.com/YVApXEm"><img src="https://i.imgur.com/YVApXEm.png" title="source: imgur.com" /></a>

※Application Insightsからログデータを見る際には、ボットに入力があってから2~5分程度のラグがある場合がありますが、通常の動きなので問題はありません。

4. 結果を.csvファイルにエクスポートし、Excel等で管理することも可能です。

<a href="https://imgur.com/V6ZeE34"><img src="https://i.imgur.com/V6ZeE34.png" title="source: imgur.com" /></a>

<a href="https://imgur.com/SvDI2EC"><img src="https://i.imgur.com/SvDI2EC.png" title="source: imgur.com" /></a>

