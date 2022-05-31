namespace WebApiStartup.DataSeeds
{
    /// <summary>
    /// 针对种子数据接口 <see cref="IDataSeed" /> 的具体实现。
    /// </summary>
    public class DataSeed : IDataSeed
    {
        private readonly DataContext? _dataContext = default;  

        public DataSeed(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task Initial()
        {
            if (_dataContext!.TeachClasses!.Any()==false)
            {
                await _dataContext!.TeachClasses!.AddRangeAsync(DataStore.TeachClassCollection!);
            }

            if (!_dataContext!.Students!.Any())
                await _dataContext!.Students!.AddRangeAsync(DataStore.StudentCollection!);

            await _dataContext!.SaveChangesAsync();
        }
    }

    /// <summary>
    /// 种子数据临时存储的静态类
    /// </summary>
    public static class DataStore
    {
        public static List<Student>? StudentCollection { get; set; }
        public static List<TeachClass>? TeachClassCollection { get; set; }

        static DataStore()
        {
            InitialTeachClassCollection();
            InitialStudentCollection();
        }

        private static void InitialTeachClassCollection()
        {
            var teachClassCollection = new List<TeachClass>()
            {
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E101"),Name ="软件2020级1班",Description="微软平台方向 ",SortCode="E101"},
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E102"),Name ="软件2020级2班",Description="Java平台方向 ",SortCode="E102"},
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E103"),Name ="软件2020级3班",Description="前端应用方向 ",SortCode="E103"},
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E104"),Name ="软件2021级1班",Description="微软平台方向",SortCode="E104"},
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E105"),Name ="软件2021级2班",Description="Java平台方向",SortCode="E105"},
                new TeachClass() { Id=Guid.Parse("6C91096A-EE81-401C-9E7A-52C05E44E106"),Name ="软件2021级3班",Description="前端应用方向",SortCode="E106"},
            };
            TeachClassCollection = teachClassCollection;
        }

        private static void InitialStudentCollection()
        {
            if (StudentCollection == null)
                StudentCollection = new List<Student>();

            if (TeachClassCollection != null)
            {
                var tc01 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2020级1班");
                var studentCollection01 = new List<Student>()
                    {
                        new Student() { Name="陈柏昌",Description="",SortCode="20143313079",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈方毅",Description="",SortCode="20143313053",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈桂英",Description="",SortCode="20143313062",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="崔福晋",Description="",SortCode="20143313047",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邓灿新",Description="",SortCode="20143313054",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邓健榕",Description="",SortCode="20143313070",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="郭彦志",Description="",SortCode="20143313050",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="胡继良",Description="",SortCode="20143313075",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄译平",Description="",SortCode="20143313068",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蒋思思",Description="",SortCode="20143313056",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李刘杰",Description="",SortCode="20143313036",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="廖旭宝",Description="",SortCode="20143313057",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林家宾",Description="",SortCode="20143313052",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘柳辉",Description="",SortCode="20143313038",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘正光",Description="",SortCode="20143313042",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="龙耀麟",Description="",SortCode="20143313073",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="卢远俊",Description="",SortCode="20143313041",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆恒展",Description="",SortCode="20143313039",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="罗荟冰",Description="",SortCode="20143313058",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="罗锦",Description="",SortCode="20143313071",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="麻略球",Description="",SortCode="20143313059",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫明剑",Description="",SortCode="20143313037",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫肖贤",Description="",SortCode="20143313051",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫洋",Description="",SortCode="20143313077",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫云波",Description="",SortCode="20143313080",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="宋芝蝶",Description="",SortCode="20143313063",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="苏加丛",Description="",SortCode="20143313044",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谭吉皓",Description="",SortCode="20143313045",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="万琴",Description="",SortCode="20140134015",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="万志新",Description="",SortCode="20140129032",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦昌报",Description="",SortCode="20143313064",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦坤沅",Description="",SortCode="20143313048",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦明朝",Description="",SortCode="20140102146",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦融",Description="",SortCode="20143313055",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴柏达",Description="",SortCode="20143203074",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴昌武",Description="",SortCode="20143313040",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴明婵",Description="",SortCode="20143313066",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨华",Description="",SortCode="20143313072",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨建林",Description="",SortCode="20143313061",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection01)
                    student.TeachClass = tc01;
                StudentCollection.AddRange(studentCollection01);

                var tc02 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2020级2班");
                var studentCollection02 = new List<Student>()
                    {
                        new Student() { Name="林文政",Description="",SortCode="20110101024",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蒋璟",Description="",SortCode="20110403032",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="秦军",Description="",SortCode="20120102107",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄二平",Description="",SortCode="20120157002",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘申继",Description="",SortCode="20123304003",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黎文新",Description="",SortCode="20123312031",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫春阳",Description="",SortCode="20123313006",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="唐瀚",Description="",SortCode="20123313009",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴空航",Description="",SortCode="20123313011",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谢显才",Description="",SortCode="20123313013",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="姚金旭",Description="",SortCode="20123313015",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李达林",Description="",SortCode="20123313019",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="方良明",Description="",SortCode="20123313020",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="冼金清",Description="",SortCode="20123313021",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吕忠挺",Description="",SortCode="20123313022",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陶靖华",Description="",SortCode="20123313023",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="王娇",Description="",SortCode="20123313024",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="农志升",Description="",SortCode="20123313025",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆科伟",Description="",SortCode="20123313026",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈栢旭",Description="",SortCode="20123313027",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黎月英",Description="",SortCode="20123313029",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="江豪贤",Description="",SortCode="20123313030",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦后礼",Description="",SortCode="20123313031",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="梁益爱",Description="",SortCode="20123313032",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="庞凤娟",Description="",SortCode="20123313035",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="祝健",Description="",SortCode="20123313036",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨邀约",Description="",SortCode="20123313037",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="潘雪华",Description="",SortCode="20123313038",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫佳丽",Description="",SortCode="20123313040",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="苏小丹",Description="",SortCode="20123313052",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蒙莲花",Description="",SortCode="20123313053",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="姜勇军",Description="",SortCode="20123313063",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邓龙",Description="",SortCode="20123313067",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="容润政",Description="",SortCode="20123314003",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection02)
                    student.TeachClass = tc02;
                StudentCollection.AddRange(studentCollection02);

                var tc03 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2020级3班");
                var studentCollection03 = new List<Student>()
                    {
                        new Student() { Name="曹朝建",Description="",SortCode="20153313059",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈宪章",Description="",SortCode="20150103086",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈雄钊",Description="",SortCode="20150132017",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈燕",Description="",SortCode="20153313015",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈梓明",Description="",SortCode="20153313030",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邓嘉",Description="",SortCode="20153313049",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邓鹏生",Description="",SortCode="20153313054",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="桂彦宾",Description="",SortCode="20153308002",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="郭明光",Description="",SortCode="20153313011",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何伟林",Description="",SortCode="20153313043",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何伟中",Description="",SortCode="20153313039",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄飞龙",Description="",SortCode="20153313056",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄立兵",Description="",SortCode="20153313026",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄联忠",Description="",SortCode="20153313031",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蓝贵铃",Description="",SortCode="20153313050",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黎圣章",Description="",SortCode="20153313018",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李森彬",Description="",SortCode="20153313051",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李唯唯",Description="",SortCode="20153313028",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="梁华明",Description="",SortCode="20153313048",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆其康",Description="",SortCode="20153313004",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="罗俊豪",Description="",SortCode="20153313042",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫千慧",Description="",SortCode="20153313023",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="潘俊",Description="",SortCode="20153309048",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="庞嫔",Description="",SortCode="20153313058",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="庞媛",Description="",SortCode="20153313047",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="石造昭",Description="",SortCode="20153313057",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="苏子翔",Description="",SortCode="20153313019",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="覃颖明",Description="",SortCode="20150132019",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谭刚官",Description="",SortCode="20153313053",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谭海棠",Description="",SortCode="20153313044",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谭燕任",Description="",SortCode="20153313016",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="王钰 ",Description="",SortCode="20153313065",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴金桃",Description="",SortCode="20153313046",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="肖忠桂",Description="",SortCode="20153313025",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="徐伟兰",Description="",SortCode="20153313073",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="许景萍",Description="",SortCode="20153313067",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="袁玉帅",Description="",SortCode="20153313052",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张露",Description="",SortCode="20153313010",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张少锦",Description="",SortCode="20153313005",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection03)
                    student.TeachClass = tc03;
                StudentCollection.AddRange(studentCollection03);

                var tc04 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2021级1班");
                var studentCollection04 = new List<Student>()
                    {
                        new Student() { Name="刘国华",Description="",SortCode="20153301012",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="梁建栋",Description="",SortCode="20153301028",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄荣锟",Description="",SortCode="20153313001",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="欧扬帆",Description="",SortCode="20153313003",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张子诚",Description="",SortCode="20153313006",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="彭克凤",Description="",SortCode="20153313007",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何万权",Description="",SortCode="20153313009",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="潘智其",Description="",SortCode="20153313012",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陀双菊",Description="",SortCode="20153313013",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何竣杰",Description="",SortCode="20153313014",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张家欣",Description="",SortCode="20153313022",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨学林",Description="",SortCode="20153313027",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="徐碧霞",Description="",SortCode="20153313029",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦云川",Description="",SortCode="20153313033",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦德刚",Description="",SortCode="20153313034",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张耀",Description="",SortCode="20153313035",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘春贵",Description="",SortCode="20153313036",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆兰萃",Description="",SortCode="20153313037",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄阳易",Description="",SortCode="20153313040",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫眀靖",Description="",SortCode="20153313060",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦献朋",Description="",SortCode="20153313062",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦辉",Description="",SortCode="20153313064",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林港华",Description="",SortCode="20153313066",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="梁昊",Description="",SortCode="20153313069",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="廖嘉俊",Description="",SortCode="20153313070",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="朱浩源",Description="",SortCode="20153313071",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张均林",Description="",SortCode="20153313072",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蒙泽云",Description="",SortCode="20153313074",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蓝李识",Description="",SortCode="20153313075",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨柳扬",Description="",SortCode="20153313076",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张光凯",Description="",SortCode="20153313077",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="曾致富",Description="",SortCode="20153313079",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="首天鹏",Description="",SortCode="20153313082",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="曾雯静",Description="",SortCode="20153313083",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="罗子言",Description="",SortCode="20153316003",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄增海",Description="",SortCode="20153316017",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦必凯",Description="",SortCode="20153316018",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="蒙有贵",Description="",SortCode="20153316025",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫广源",Description="",SortCode="20153316032",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection04)
                    student.TeachClass = tc04;
                StudentCollection.AddRange(studentCollection04);

                var tc05 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2021级2班");
                var studentCollection05 = new List<Student>()
                    {
                        new Student() { Name="潘虹言",Description="",SortCode="20130102017",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄深",Description="",SortCode="20130503010",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘小丽",Description="",SortCode="20133308001",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦佳志",Description="",SortCode="20133309035",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="纪健",Description="",SortCode="20133309060",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘德益",Description="",SortCode="20133312003",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈天波",Description="",SortCode="20133313018",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="吴远源",Description="",SortCode="20133313020",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆荣华",Description="",SortCode="20133313024",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="缪昆儒",Description="",SortCode="20133313026",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李勋文",Description="",SortCode="20133313030",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="余伟杰",Description="",SortCode="20133313036",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="廖添秋",Description="",SortCode="20133313039",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="唐当植",Description="",SortCode="20133313041",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦红艳",Description="",SortCode="20133313043",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="谢昆",Description="",SortCode="20133313047",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="杨家俊",Description="",SortCode="20133313049",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="尹平业",Description="",SortCode="20133313050",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李仁杰",Description="",SortCode="20133313051",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦良磊",Description="",SortCode="20133313055",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李师松",Description="",SortCode="20133313057",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="胡明桂",Description="",SortCode="20133313060",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆日祥",Description="",SortCode="20133313061",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="莫静锋",Description="",SortCode="20133313062",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="马业榜",Description="",SortCode="20133313065",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦运培",Description="",SortCode="20133313068",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="周春丽",Description="",SortCode="20133313072",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="钟珊珊",Description="",SortCode="20133313077",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="刘妙莲",Description="",SortCode="20133313078",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林舒晴",Description="",SortCode="20133313083",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄树发",Description="",SortCode="20133313089",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="李波",Description="",SortCode="20133313092",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陈威宇",Description="",SortCode="20133313095",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="周夏",Description="",SortCode="20133313096",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林见阳",Description="",SortCode="20133313098",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林钰森",Description="",SortCode="20133313099",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="唐春旺",Description="",SortCode="20133313101",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection05)
                    student.TeachClass = tc05;
                StudentCollection.AddRange(studentCollection05);

                var tc06 = TeachClassCollection.FirstOrDefault(x => x.Name == "软件2021级3班");
                var studentCollection06 = new List<Student>()
                    {
                        new Student() { Name="覃助林",Description="",SortCode="20123313018",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何海 ",Description="",SortCode="20123313028",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="赖善栋",Description="",SortCode="20123313039",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="孙迪 ",Description="",SortCode="20123313041",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="苏捷林",Description="",SortCode="20123313042",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="文国 ",Description="",SortCode="20123313043",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="庾飞 ",Description="",SortCode="20123313045",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="易远霞",Description="",SortCode="20123313046",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="周成婷",Description="",SortCode="20123313047",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="邹世庭",Description="",SortCode="20123313048",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦智",Description="",SortCode="20123313049",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="张春唯",Description="",SortCode="20123313050",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陶灵 ",Description="",SortCode="20123313051",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="陆本兴",Description="",SortCode="20123313054",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="农仕冰",Description="",SortCode="20123313055",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄正悦",Description="",SortCode="20123313057",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="何劲锋",Description="",SortCode="20123313058",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="叶剑 ",Description="",SortCode="20123313059",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="兰海堂",Description="",SortCode="20123313060",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林达杰",Description="",SortCode="20123313061",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="罗扬成",Description="",SortCode="20123313062",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="丘展鹏",Description="",SortCode="20123313064",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="甘立光",Description="",SortCode="20123313065",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="韦中昌",Description="",SortCode="20123313066",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="朱万军",Description="",SortCode="20123313068",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄海勇",Description="",SortCode="20123313069",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="温亦康",Description="",SortCode="20123313070",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="林祖健",Description="",SortCode="20123313071",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="宁天樑",Description="",SortCode="20123314004",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                        new Student() { Name="黄叙旗",Description="",SortCode="20123314005",BirthDay=DateTime.Now, Gender=true, Province="广西"},
                    };
                foreach (var student in studentCollection06)
                    student.TeachClass = tc06;
                StudentCollection.AddRange(studentCollection06);

            }
        }
    }

}
