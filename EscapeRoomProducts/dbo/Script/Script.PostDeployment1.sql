/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------

INSERT INTO Game(Title, Tag, LongPic, Banner, Button, Capacity, Length, RunStart, RunEnd, Color, Description)
VALUES('Sub Surface', 'Time and air are running out!', '../Content/Images/engWall375x200.jpg', '../Content/Images/goggles250x375.jpg',	'Dive!', 20, 120, '05/15/2017 7:30:00 PM', '2016-10-27 7:30:00 pm', '#F4ECF7', 'Plummet to the depths of the ocean to rescue the crew of the SS Endeavor. Lorem ipsum dolor sit amet, per congue ac, non velit et nisl nec, proin sed odio mollis, eget eu aliquam pellentesque orci, risus tempus pellentesque posuere vehicula elit. Cum volutpat elit vel ad vivamus risus, quis curabitur elementum, interdum vestibulum volutpat fames wisi sed, ligula massa lacus ut in a. Et dolor tempus etiam accumsan suspendisse non, quisque sagittis vivamus dui quam imperdiet, pretium arcu donec molestie porttitor praesent. Nunc gravida nulla id maecenas, faucibus fusce suspendisse metus in esse ac, semper sem vel amet nulla a in, sed eros ex, viverra eu fringilla eu ut mauris. Lectus in purus, justo tortor platea turpis pellentesque, faucibus optio condimentum suscipit augue nullam id, tortor vestibulum amet metus nunc faucibus.  Metus orci eu erat elit, sit congue, nibh sit ut dolor tempus ipsum, vel imperdiet. Pretium ligula metus ornare fermentum. Massa eros sed fusce. Tellus tempus et dui vitae luctus tellus, torquent auctor sed luctus ut ut gravida, praesent risus aliquam mauris libero orci est. In commodo lorem sem ac, volutpat elementum dolore lorem condimentum. Sodales eu vehicula ullamcorper nam est. Eget interdum fuga eu pede eget tincidunt, dis accusamus vestibulum proin purus mi, nulla mollis quisque suspendisse ullamcorper.'),
		('The Last Defender', 'Race the clock against nuclear destruction!', '../Content/Images/colors375x200.jpg', '../Content/Images/controlPanel250x375.jpg', 'Defend', 16, 90, '11/1/2016 7:30:00 PM', '3/15/2017 9:00:00 PM', '#FEF9E7', 'Welcome to the Defenders - the last hope for nuclear peace. Lorem ipsum dolor sit amet, per congue ac, non velit et nisl nec, proin sed odio mollis, eget eu aliquam pellentesque orci, risus tempus pellentesque posuere vehicula elit. Cum volutpat elit vel ad vivamus risus, quis curabitur elementum, interdum vestibulum volutpat fames wisi sed, ligula massa lacus ut in a. Et dolor tempus etiam accumsan suspendisse non, quisque sagittis vivamus dui quam imperdiet, pretium arcu donec molestie porttitor praesent. Nunc gravida nulla id maecenas, faucibus fusce suspendisse metus in esse ac, semper sem vel amet nulla a in, sed eros ex, viverra eu fringilla eu ut mauris. Lectus in purus, justo tortor platea turpis pellentesque, faucibus optio condimentum suscipit augue nullam id, tortor vestibulum amet metus nunc faucibus. Metus orci eu erat elit, sit congue, nibh sit ut dolor tempus ipsum, vel imperdiet. Pretium ligula metus ornare fermentum. Massa eros sed fusce. Tellus tempus et dui vitae luctus tellus, torquent auctor sed luctus ut ut gravida, praesent risus aliquam mauris libero orci est. In commodo lorem sem ac, volutpat elementum dolore lorem condimentum. Sodales eu vehicula ullamcorper nam est. Eget interdum fuga eu pede eget tincidunt, dis accusamus vestibulum proin purus mi, nulla mollis quisque suspendisse ullamcorper.')


Insert Into [Session](start, price, soldOut, title, color)
Values
('10/28/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('10/28/2016 9:30:00 PM',	40,	0,	'Sub Surface',	'Blue'),
('10/28/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/3/2016 7:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/3/2016 9:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/4/2016 7:30:00 PM',		50,	0,	'The Last Defender',	'Orange'),
('11/4/2016 9:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/5/2016 7:30:00 PM',		50,	0,	'The Last Defender',	'Orange'),
('11/5/2016 9:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/6/2016 7:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/6/2016 9:30:00 PM',		45,	0,	'The Last Defender',	'Orange'),
('11/10/2016 7:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/10/2016 9:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/11/2016 7:30:00 PM',	50,	0,	'The Last Defender',	'Orange'),
('11/11/2016 9:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/12/2016 7:30:00 PM',	50,	0,	'The Last Defender',	'Orange'),
('11/12/2016 9:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/13/2016 7:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/13/2016 9:30:00 PM',	45,	0,	'The Last Defender',	'Orange'),
('11/10/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/10/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/11/2016 7:30:00 PM',	50,	0,	'Sub Surface',	'Blue'),
('11/11/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/12/2016 7:30:00 PM',	50,	0,	'Sub Surface',	'Blue'),
('11/12/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/13/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/13/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/3/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/3/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/4/2016 7:30:00 PM',	50,	0,	'Sub Surface',	'Blue'),
('11/4/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/5/2016 7:30:00 PM',	50,	0,	'Sub Surface',	'Blue'),
('11/5/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/6/2016 7:30:00 PM',	45,	0,	'Sub Surface',	'Blue'),
('11/6/2016 9:30:00 PM',	45,	0,	'Sub Surface',	'Blue')

