LivetSample
===========

## Setup

* NuGet で LivetCask をインストール
* MainWindow.xaml を削除
* 新しい項目の追加から「Livet WPF Window」で MainWindow.xaml を追加
* xmlns:behaviors → xmlns:i に変更 (長いから)
* 新しい項目の追加から「Livet WPF ViewModel」で MainWindowViewModel.cs を追加
* xmlns:vm で ViewModel の namespace を追加
* Window.DataContext に vm:MainWindowViewModel を追加



