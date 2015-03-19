API_VERSION=`git describe --abbrev=0`
npm install replace
./node_modules/.bin/replace "(<|</)\bversion(>)\b\d*[.]?\d*[.]?\d*[.]?\d*[.]?\d(<|</)\bversion(>)" "<version>$API_VERSION</version>" adaptive-arp-api.nuspec
