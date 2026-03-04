# mymain001

## 概要
`mymain001` は主に C#（約 59.7%）と HTML（約 39.4%）で構成されたリポジトリです。リポジトリ内には C# ソースをまとめた `CSarpSorce/` ディレクトリと、静的 HTML ページを含む `MyHTML/` ディレクトリ、ルートの `index.html` などのファイルがあります。この README はリポジトリ全体の目的、現在の進捗、実際のディレクトリ構成に合わせたビルド／実行方法、貢献手順などをまとめたものです。

## 目次
- 概要
- 現在の進捗
- 主要機能
- リポジトリ構成（実際）
- 必要環境
- ビルドと実行（実ファイルパス）
- テスト
- デプロイ（簡易）
- 貢献方法
- ライセンス
- 連絡先

## 現在の進捗
- 言語構成：C#（約 59.7%）、HTML（約 39.4%）、その他 0.9%。
- C# のサンプル/プロジェクトが `CSarpSorce/` 配下に存在します（例: `CSarpSorce/csh/`, `CSarpSorce/OhMyPC/`, `CSarpSorce/ClassLibrary1/`）。
- HTML ページは `MyHTML/` とルートの `index.html` にあります。

## 主要機能（想定）
- C# サンプルアプリ（コンソール / ライブラリ）
- 静的 HTML ページの提供
- 将来的に ASP.NET ベースの Web アプリ化を想定可能

## リポジトリ構成（実際）
- /CSarpSorce/
  - /csh/ — コンソールアプリのソース（Program.cs など）
  - /ConsoleApp1/ — 追加のサンプルアプリ（Resources 配下に HTML 等あり）
  - /OhMyPC/ — 別プロジェクト（ビルド成果物や obj/ bin/ が含まれることがあります）
  - /ClassLibrary1/ — ライブラリソース
- /MyHTML/ — 静的 HTML ページ（Index.html, HTMLPage1.html など）
- /index.html — ルートの HTML
- その他: googled*.html などの検証ファイル

（注意: 一部のファイルにビルド生成ファイル（obj/、bin/）や個人環��に依存するパスが含まれている可能性があります。必要なら .gitignore を整備してください。）

## 必要環境
- .NET SDK（プロジェクトに合わせて .NET 6/7/10 などが使われている可能性があります。例: net10.0 の出力があるため .NET 10 が参照されている箇所があります）
  - ダウンロード: https://dotnet.microsoft.com/
- Git

## ビルドと実行（実ファイルパスの例）
1. リポジトリをクローン:
   - git clone https://github.com/minecraft0036/mymain001.git
2. 依存関係を復元とビルド（例）:
   - cd mymain001
   - dotnet restore CSarpSorce/csh/csh.csproj
   - dotnet build CSarpSorce/csh/csh.csproj
3. 実行（コンソールアプリの例）:
   - dotnet run --project ./CSarpSorce/csh/csh.csproj
   - あるいは他プロジェクトを実行: dotnet run --project ./CSarpSorce/OhMyPC/OhMyPC.csproj
4. 静的ページの確認:
   - ブラウザで `index.html` または `MyHTML/Index.html` を開く

※ 実際にどのターゲットフレームワークを使うかは各 .csproj を確認してください。

## テスト
- リポジトリ内に tests フォルダが見つからない場合は未設定です。テストプロジェクトがある場合は `dotnet test <path-to-test-csproj>` を実行してください。

## デプロイ（簡易）
- 必要に応じて Dockerfile を作成し、個別プロジェクトをコンテナ化してください。
- 静的ページは GitHub Pages で公開できます（`index.html` をルートに置いて repo の Pages を有効化）。

## コントリビューション
1. Issue を立てて変更内容や目的を共有してください。
2. 新しい機能や修正はブランチを切ってください（例: `feat/xxx`、`fix/yyy`）。
3. Pull Request を作成し、内容と動作確認手順を記載してください。

## 注意点: クリーンアップ提案
- `obj/` や `bin/`、個人環境を示す絶対パスが含まれるファイルはコミット対象から外すため `.gitignore` を整備することをおすすめします。
- 機密情報やローカルのフルパスが含まれていないか確認してください。

## ライセンス
- LICENSE ファイルを追加してください（例: MIT）。

## 連絡先
- リポジトリオーナー: @minecraft0036
