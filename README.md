# SNMPv3EngineId-Format
This is a windows forms appliation(based on .net6.0) used to format SNMPEngineId followed RFC3411.

![][/images/seifor.png]

# How to use
How to use:

Fill three parameters:
1. Private Enterpice Number assigned by [IANA](!https://www.iana.org/assignments/enterprise-numbers)
2. Select Engine ID Data Format: 1 for IPv4(only support in this version )
3. Fill the Engine ID Data base on the data format.

### Result
The reuslt generates engineID based on the lines in Engine ID data like below:

![][/images/seifor-main-function-ipv4.png]

### Error notify
An error is shown out in the Result once the three parameters are not matched the requirement. Like:
- empty input
- wrong IPv4 format

![][/images/seifor-error-notice.png]


### About
About can be opened in the main forms.

In about, the help info is there and also shown how to report bug with scan the QR:

![][/images/seifor-about.png]

Welcome to raise any issue in this repository or in Wechat Offical Acount (qiheyehk)
![][/images/qiheyehk.jpg]
