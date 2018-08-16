# ChatBotSample_SkypeforBiz_AppInsights

Azure Bot FrameworkとQnA Maker Serviceを用いて作成した、Skype for Business用ChatBotのサンプルコード(C#版)です。Application Insightsを用いて、チャットログのトレースを行うことができます。
Visual Studioを用いずに、Azureポータル上の簡単な設定だけでChatBotを動かすことが出来ます。Skype for BusinessではRich Interface(選択ボタンetc)が機能しないため、数字での入力をユーザに促す設定になっています。 

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
