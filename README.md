# SNMPv3EngineId-Format
This is a windows forms appliation(based on .net6.0) used to format SNMPEngineId followed RFC3411.
![][1]

The name SeiFor is short of SNMP EnginedID Foramrt.

# How to use

## Main Function

Fill three parameters:
1. Private Enterpice Number assigned by [IANA](https://www.iana.org/assignments/enterprise-numbers)
2. Select Engine ID Data Format: 1 for IPv4(only support in this version )
3. Fill the Engine ID Data base on the data format.

![][2]

### Result
The reuslt generates engineID based on the lines in Engine ID data like below:

![][2]

### Error notify
An error is shown out in the Result once the three parameters are not matched the requirement. Like:
- empty input
- wrong IPv4 format

![][3]

![][4]

![][5]

## About
About can be opened in the main forms.

In about, the help info is there and also shown how to report bug with scan the QR:

![][6]

Welcome to raise any issue in this repository or in Wechat Offical Acount (qiheyehk)

![][7]

## Decode an engineID
This function is added in version 2 which can be opened in the main forms.

This function is used to decode a knowned engineID to readable format.

![][8]

# Version 
Version 1(2023-02-20)
- First Version

Version 2(2023-03-04)
- Fix typo
- Update EngineID data format to support IPv6, MAC and Text assigned by admin.
- Add PEN range(0-99999) check.
- Update about with hyperlink for RFC and IANA link
- Add decode function for decoding an engineID


# How to get
Fork this repository and the exe file in https://github.com/MinpuKang/SNMPv3EngineId-Format/tree/main/SeiFor/bin/Debug/net6.0-windows

Note: must download the whole folder of net6.0-windows, otherwise the exe file cannot run

Or follow Wechat Offical Acount (qiheyehk) and send **snmp** to get the download link.

![][7]



[1]: https://mmbiz.qpic.cn/mmbiz_png/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhqrY2SynCJ1H0SeuvNN8dGJiaekUogTyiaYF12KRfUA12NOL6mic8Dngvg/0?wx_fmt=png


[2]: https://mmbiz.qpic.cn/mmbiz_gif/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhDNSeR1TBpcia2S0vpABEnG4zBGUrWYsyJ9vicSicvfqiaXTUPVKBvPqrYQ/0?wx_fmt=gif


[3]: https://mmbiz.qpic.cn/mmbiz_gif/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhYZqCrNsRzFhtKCOJ9buVibhvX6GiaaJ28ic1WUT7MfJGHicUCZHNmHaxWg/0?wx_fmt=gif


[4]: https://mmbiz.qpic.cn/mmbiz_png/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhiasaxN7UvpeabEyEgsiarw9E5owakovbTEl2GAeg3gPrnYK9u8qmRn6A/0?wx_fmt=png


[5]: https://mmbiz.qpic.cn/mmbiz_png/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhxUnORTBSbRRA9ic6TOiaV2aVCAIyBmslBg1sTg8W7R5iajEialE1xWI2Sw/0?wx_fmt=png


[6]: https://mmbiz.qpic.cn/mmbiz_png/QqiaFS6NT0eA6EWAZxwatygjwC4xo6jWhpqYDTbv7bEJ8EBtCZvTTBatBca973TeGN7uRopicy58ZxENEbCgoianQ/0?wx_fmt=png


[7]: https://mmbiz.qpic.cn/mmbiz_jpg/QqiaFS6NT0eCNHPVGlL7eS3WvZzMzLn95SVJVyDgsNNdEAxibsvkqnh3FzicaYJyUxYpv5u1vZn6cBfbhBLEEIHIw/0?wx_fmt=jpeg


[8]: https://mmbiz.qpic.cn/mmbiz_png/QqiaFS6NT0eCNHPVGlL7eS3WvZzMzLn95yFN13UqaKTiazFyIAuicvPZfkQKIgIichDB2JXQjdUbmVOll2P61DD5aQ/0?wx_fmt=png