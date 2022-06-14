git config --global core.autocrlf false
git clone --single-branch --branch master https://github.com/algorand/algorand-sdk-testing.git ../test-harness
bash ../test-harness/scripts/up.sh -s