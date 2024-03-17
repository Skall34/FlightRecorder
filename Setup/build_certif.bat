rem create the base certificate & private key
openssl req -x509 -sha256 -nodes -days 365 -newkey rsa:2048 -keyout privateKey.key -out certificate.crt
rem create the pfx 
openssl pkcs12 -export -out SKWCertifFull.pfx -inkey privateKey.key -in certificate.crt
rem convert it to base 64 to be store as secret in github
openssl base64 -in SKWCertifFull.pfx -out SKWCertifFull_64.txt
rem get the sha1 checksum for the certificate (don't forget to remove the ':' when putting sha1 into a github scret

openssl x509 -in certificate.crt -out sha1.txt -fingerprint -sha1
rem sign the code
signtool sign /f SKWCertifFull.pfx /fd SHA1 /p ***** /t http://timestamp.digicert.com ..\Build\Flight_Recorder_setup_0.0.0.0.exe




