cd ..\..\
md Assets
md Assets\Plugins
md Assets\Plugins\Editor
md Assets\Plugins\uFrame
cd Assets\Plugins\uFrame
git clone -b 2.0 https://github.com/InvertGames/uFrameKernel.git
git clone https://github.com/InvertGames/Invert.Common.git
git clone https://github.com/InvertGames/UniRx.git
git clone https://github.com/InvertGames/uFrame.ECS.Actions.git
git clone https://github.com/InvertGames/uFrame.Documentation.git
cd ..\..\..\
cd Assets\Plugins
git clone https://github.com/InvertGames/uFrame.ECS.git
cd ..\..\
cd Assets\Plugins\Editor
git clone https://github.com/InvertGames/uFrame.ECS.Editor.git
git clone https://github.com/InvertGames/uFrame.ECS.Templates.git
git clone https://github.com/InvertGames/uFrame.Editor.git
git clone https://github.com/InvertGames/uFrame.Resources
cd ..\..\..\