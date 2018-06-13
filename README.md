# Isalore
Electron.NET app prototype


xhost local:root

docker run -v /tmp/.X11-unix:/tmp/.X11-unix -e DISPLAY=$DISPLAY --device /dev/dri --device /dev/snd -v /etc/localtime:/etc/localtime:ro -v $HOME/.config/app:/root/.config/app isalore_isalore dotnet electronize start