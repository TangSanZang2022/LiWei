mergeInto(LibraryManager.library, {

    StartTime: function () { //StartTime是Unity调用的方法名字
        BeginTime(); //BeginTime是调用前端BeginTime()方法
    },
	 HelloString: function (str) { //HelloString是Unity调用的方法名字
        GetHello(Pointer_stringify(str)); //GetHello是调用前端GetHello()方法
    },
	GetMsg: function(){
	var returnStr = GetIPInformation();
	var bufferSize = lengthBytesUTF8(returnStr) + 1;
	var buffer = _malloc(bufferSize);
	stringToUTF8(returnStr, buffer, bufferSize);
	return buffer;
  }, 
});
