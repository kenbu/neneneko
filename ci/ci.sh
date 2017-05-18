#!/bin/sh


/Applications/Unity/Unity.app/Contents/MacOS/Unity -logFile ${WORKSPACE}Editor.log -projectPath ${WORKSPACE}/Neneneko -executeMethod NenenekoCI.StartTest

result=$?


echo ${result}

if [ "$result" = "1" ]
then
	echo "問題あり"
	#一旦固定パスで動画生成
	echo "----動画出力----"
	ffmpeg -i ${WORKSPACE}/Neneneko/Assets/kenbu/Neneneko/Captured/%d.png -pix_fmt yuv420p ${WORKSPACE}/Neneneko/Assets/kenbu/Neneneko/Captured/result.mp4

	#エラーを返す

	#todo: ログなんか
	return 1
else
	echo "問題なし"
fi
