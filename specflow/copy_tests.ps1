git config --global core.autocrlf false
git clone --single-branch --branch master https://github.com/algorand/algorand-sdk-testing.git ../test-harness
Copy-Item  -Path "..\test-harness\features\resources\*" -Destination ".\Features\resources" -Recurse
Copy-Item  -Path "..\test-harness\features\unit\v2algodclient_responsejsons\*" -Destination ".\Features\unit\v2algodclient_responsejsons" -Recurse
Copy-Item  -Path "..\test-harness\features\unit\v2algodclient_paths.feature" -Destination ".\Features\unit\v2algodclient_paths.feature" 
Copy-Item  -Path "..\test-harness\features\unit\v2algodclient_responses.feature" -Destination ".\Features\unit\v2algodclient_responses.feature" 

