git config --global core.autocrlf false
git clone --single-branch --branch master https://github.com/algorand/algorand-sdk-testing.git ../test-harness
cd ../test-harness
bash scripts/up.sh -s