﻿--테이블에 있는 레코드의 개수를 구하는 저장 프로시저
Create Proc dbo.GetCountNotes
As
	Select Count(*) From Notes
Go