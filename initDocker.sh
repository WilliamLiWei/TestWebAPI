docker ps --filter "name=apidemo" --format {{.ID}} -n 1
if [ $? -eq 0 ];then
  #output 0, mean exec success
  docker stop apidemo
  docker rm apidemo
  docker rmi webapidemo:latest
else
  echo "no"
fi
