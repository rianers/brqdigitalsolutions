#!/bin/bash

docker build -t brqdigitalsolutions .

heroku container:push web -a brqdigitalsolutions

heroku container:release web -a brqdigitalsolutions
