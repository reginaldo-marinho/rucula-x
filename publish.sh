#!/bin/bash

if [ -z "$1" ]; then
  echo "Uso: ./publicar.sh <comando> <projeto.csproj>"
  exit 1
fi

COMMAND="$1"
PROJECT="$2"

if [ "$1" = "publish-local" ]; then
  dotnet pack $PROJECT
fi