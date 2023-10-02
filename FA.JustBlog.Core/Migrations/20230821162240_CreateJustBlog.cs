using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class CreateJustBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(name: "Short Description", type: "nvarchar(max)", nullable: false),
                    PostContent = table.Column<string>(name: "Post Content", type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(name: "Posted On", type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMap",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMap", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMap_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMap_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, "thể thao", "Thể thao", "the-thao" },
                    { 2, "Giáo dục", "Giáo dục", "giao-duc" },
                    { 3, "Sức khỏe", "Sức khỏe", "suc-khoe" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, "Giảm cân", "Giảm cân", "giam-can" },
                    { 2, 1, "Dị ứng", "Dị ứng", "di-ung" },
                    { 3, 1, "Sỏi thận", "Sỏi thận", "soi-than" },
                    { 4, 1, "Trường chuyên", "Trường chuyên", "truong-chuyen" },
                    { 5, 1, "Công nghệ", "Công nghệ", "cong-nghe" },
                    { 6, 1, "Đại học", "Đại học", "dai-hoc" },
                    { 7, 1, "Bóng đá", "Bóng đá", "bong-da" },
                    { 8, 1, "Bóng đá", "Bóng đá", "bong-da" },
                    { 9, 1, "VFF", "VFF", "VFF" },
                    { 10, 1, "Xạ thủ", "Xạ thủ", "xa-thu" },
                    { 11, 1, "Olympic Paris 2024", "Olympic Paris 2024", "olympic-paris-2024" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "Post Content", "Posted On", "Published", "Short Description", "Title", "UrlSlug" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1364), "Trịnh Thu Vinh giành vé nhờ thành tích tại giải VĐTG (ISSFWC) 2023 tổ chức tại Baku, Azerbaijan. Xạ thủ này tham dự nội dung 10m súng ngắn hơi nữ trong ngày khai mạc hôm nay 17/8. \nỞ vòng loại, Thu Vinh đạt 579 điểm để xếp thứ năm, qua đó vào nhóm tám xạ thủ thi chung kết. Phần thi chung kết bắt đầu loại dần VĐV từ lượt bắn thứ tư, và Thu Vinh trụ đến loạt thứ sáu với 175,6 điểm.Xạ thủ Trung Quốc Jiang Ranxin giành HC vàng với 239,8 điểm sau tám loạt bắn. Xếp sau lần lượt là VĐV Hy Lạp Korakaki Anna - 238,3 điểm, VĐV Trung Quốc Li Xue - 218,9 điểm, và VĐV Hungary Fabian Sara Rahel - 198,9 điểm.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1350), true, "Sau cua-rơ Nguyễn Thị Thật, xạ thủ Trịnh Thu Vinh trở thành VĐV Việt Nam thứ hai có vé đến Olympic Paris 2024.", "Việt Nam có vé thứ hai dự Olympic Paris 2024", "the-thao" },
                    { 2, 1, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1367), "Ngày 30/7, Kiên Giang thua 0-6 Đồng Nai trên sân nhà. Thủ môn Nguyễn Văn Bá thủng lưới năm bàn trong hiệp hai và phải nhận hai thẻ vàng liên tiếp từ trọng tài chính ở phút 90 và phút bù thứ nhất.\r\n\r\nSau khi nhận báo cáo từ giám sát trận đấu Nguyễn Tấn Long, trọng tài Nguyễn Kim Việt Bảo, Ban kỷ luật VFF xác định thủ môn Nguyễn Văn Bá cố tình buông xuôi để thua thêm bàn.\r\n\r\nNgày 18/8, Ban kỷ luật VFF quyết định phạt Nguyễn Văn Bá 10 triệu đồng và cấm tham gia hoạt động bóng đá 24 tháng tại các giải do VFF quản lý, tổ chức. Nguyễn Văn Bá được xác định vi phạm Điều 52 về dàn xếp trận đấu, tỷ số, cụ thể thi đấu không đúng khả năng và làm sai lệch kết quả trận đấu.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1366), true, "Thủ môn Nguyễn Văn Bá của Kiên Giang bị cấm thi đấu kịch khung do thi đấu tiêu cực ở vòng 13 bảng B giải hạng Nhì 2023.", "VFF cấm thi đấu hai năm thủ môn giải hạng Nhì", "vff-cam-thi-dau-hai-nam-thu-mon-giai-hang-nhi" },
                    { 3, 1, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1368), "Hôm 15/8, Quế Ngọc Hải đã gặp Chủ tịch CLB SLNA Trương Sỹ Bá, đề đạt nguyện vọng được ra đi dù hợp đồng còn thời hạn đến hết năm 2024.Lãnh đạo đội bóng xứ Nghệ chấp thuận, thậm chí không đòi lại khoản tiền lót tay còn lại trong các tháng cuối năm 2023. Ngọc Hải đang chờ giấy thanh lý hợp đồng. Anh hiện nhận được sự quan tâm từ CLB Hà Tĩnh và Nam Định.\r\n\r\nQuế Ngọc Hải sinh năm 1993, trưởng thành từ lò đào tạo SLNA, lên chơi cho đội một năm 2012. Anh chơi cho đội bóng xứ Nghệ sáu mùa, từng được đeo băng đội trưởng trước khi gia nhập Viettel năm 2018.\r\n\r\n", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1368), true, "Trung vệ thủ quân Quế Ngọc Hải xin thanh lý hợp đồng trước thời hạn một năm và nhận được sự đồng ý của lãnh đạo CLB SLNA.", "Quế Ngọc Hải chia tay SLNA", "que-ngoc-hai-chia-tay-slna" },
                    { 4, 2, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1370), "Tại hội nghị Tổng kết năm học 2022-2023 và triển khai nhiệm vụ năm học 2023-2024 do Bộ Giáo dục và Đào tạo tổ chức chiều 18/8, PGS.TS Vũ Hải Quân cho biết tự chủ đại học ghi nhận nhiều kết quả tích cực. \nNhư tại Đại học Quốc gia TP HCM, 6 trường thành viên đã tự chủ chi thường xuyên (chi lương, phụ cấp, dịch vụ công cộng, sửa chữa tài sản...). Trường nằm trong top 1.000 đại học hàng đầu thế giới, 126 chương trình đào tạo đã đạt chuẩn kiểm định quốc tế. Năm ngoái, Đại học Quốc gia TP HCM công bố gần 2.400 bài báo quốc tế trong danh mục Scopus, chiếm hơn 12% tổng số công bố của cả nước. \nTuy nhiên, ông Quân nhìn nhận tiến trình tự chủ đại học ở Việt Nam thời gian qua gặp thách thức rất lớn như: nguồn thu chủ yếu dựa vào học phí; chính sách cho sinh viên vay còn rất hạn chế, cả về diện được vay lẫn quy trình thủ tục, định mức và thời hạn vay; một số quy định về pháp luật chưa đồng bộ, chưa thúc đẩy tự chủ đại học; mất cân đối trong lĩnh vực ngành nghề đào tạo khi ít sinh viên chọn ngành khoa học, kỹ thuật công nghệ.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1369), true, "Ông Vũ Hải Quân, Giám đốc Đại học Quốc gia TP HCM, cho rằng tự chủ đại học ở Việt Nam gặp thách thức rất lớn về tài chính, với cả cơ sở đào tạo và người học.", "Đại học gặp thách thức rất lớn về tài chính khi tự chủ", "dai-hoc-gap-thach-thuc-rat-lon-ve-tai-chinh-khi-tu-chu" },
                    { 5, 2, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1371), "Theo em tìm hiểu, giáo trình của ba ngành này đều dạy lập trình. Khoa học máy tính có vẻ dạy lập trình nhiều nhất, Tự động hóa ít nhất.Ban đầu em phân vân giữa Điện tử viễn thông và Tự động hóa, nhưng giờ nghe mọi người bảo cơ hội việc làm của Khoa học máy tính tốt hơn, em khá đắn đo. Nhờ mọi người tư vấn giúp em về môi trường làm việc, lương và các công việc phù hợp với mỗi ngành sau tốt nghiệp ạ. \n", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1371), true, "Em khá thích lập trình, chế tạo các loại máy móc, thiết bị nhưng chưa biết chọn Tự động hóa, Điện tử viễn thông hay Khoa học máy tính.", "Nên chọn Tự động hóa, Điện tử viễn thông hay Khoa học máy tính?", "nen-chon-tu-dong-hoa-dien-tu-vien-thong-hay-khoa-hoc-may-tinh" },
                    { 6, 2, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1373), "Thông tin được đưa ra tại Hội nghị triển khai nhiệm vụ năm học mới bậc THCS của Sở Giáo dục và Đào tạo Hà Nội, chiều 18/8. Lãnh đạo Sở cho hay theo quy chế hoạt động trường THPT chuyên, Bộ Giáo dục và Đào tạo yêu cầu không tổ chức lớp không chuyên trong trường chuyên. \nTrong khi đó, hiện hai trường THPT Chu Văn An (quận Tây Hồ) và THPT Sơn Tây (thị xã Sơn Tây) tồn tại cả mô hình lớp chuyên và không chuyên. Do đó, Sở dự kiến xây dựng đề án, chuyển hai trường này thành trường chuyên. \nTrước dự kiến này, đại diện Phòng Giáo dục và Đào tạo thị xã Sơn Tây bày tỏ băn khoăn vì hiện trên địa bàn có ít trường THPT công lập. Nếu THPT Sơn Tây chuyển thành trường chuyên thì chỉ tiêu cho hệ thường không còn. \n", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1372), true, "Sở Giáo dục và Đào tạo Hà Nội dự kiến xây dựng đề án, chuyển trường THPT Chu Văn An và Sơn Tây thành trường chuyên.", "Hà Nội có thể thêm hai trường chuyên", "ha-noi-co-the-them-hai-truong-chuyen" },
                    { 7, 3, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1376), "BS.CKII Đinh Cẩm Tú, Trưởng Đơn vị Thận nhân tạo, Trung tâm Tiết niệu - Thận học - Nam khoa, Bệnh viện Đa khoa Tâm Anh TP HCM, cho biết sỏi thận là nguyên nhân chính gây ra cơn đau quặn thận (cơn đau bão thận). \nSỏi di chuyển theo chiều xuôi, từ thận qua bàng quang đến niệu đạo để đào thải khỏi cơ thể. Nếu sỏi mắc kẹt trong đường tiết niệu, cản trở dòng nước tiểu. Ngoài gây đau, bế tắc đường tiểu, tình trạng này còn làm tăng áp lực và viêm nhiễm hệ tiết niệu \nVị trí đau phụ thuộc vào vị trí và sự di chuyển của sỏi trong hệ tiết niệu. Triệu chứng điển hình của cơn đau bão thận là đau dữ dội, đột ngột khởi phát từ mạn sườn một bên, lan đến giữa xương sườn dưới và hông. Cơn đau có thể lan ra lưng, bụng dưới hoặc hướng về bẹn. Đau xuất hiện thành từng đợt, thường kèm theo buồn nôn. \nCác triệu chứng khác như lượng nước tiểu ít hơn bình thường, đi tiểu gấp, đau khi đi tiểu, có máu trong nước tiểu, nước tiểu đục, có mùi hôi... Người bệnh có thể bị sốt kèm ớn lạnh.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1375), true, "Viên sỏi rơi từ thận xuống đường tiết niệu, làm tắc nghẽn đường tiểu, gây ra cơn đau đột ngột, tăng dần, kéo dài nhiều giờ.", "Cơn đau do sỏi thận", "con-dau-do-soi-than" },
                    { 8, 3, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1379), "Theo Hiệp hội Da liễu Mỹ (AAD), da ngứa có thể do khô, dị ứng, ký sinh trùng, vết côn trùng cắn, bệnh vẩy nến, viêm da dị ứng. Nguyên nhân nghiêm trọng khác như bệnh thận, tiểu đường, HIV. \nHầu hết trường hợp có thể dùng thuốc để giảm ngứa. Chế độ ăn cũng góp phần cải thiện tình trạng, ngăn ngừa các vấn đề kích ứng da khác.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1379), true, "Cá béo, trái cây chứa vitamin C, E và quercetin có khả năng chống viêm, hỗ trợ giảm ngứa khi da bị kích ứng.", "Ăn gì giảm ngứa da?", "an-gi-giam-ngua-da" },
                    { 9, 3, new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1381), "Nguyễn Thị Tuyết Huỳnh, cao 1,63 m, từng nặng 62 kg, tìm đến nhiều phương pháp giảm cân cực đoan như nhịn ăn, tập luyện cường độ cao, kèm thuốc giảm cân. Mỗi bữa, cô ăn rất ít, chủ yếu là ức gà và rau luộc, loại bỏ hoàn toàn tinh bột, ép bản thân tập thể dục 3-4 tiếng một ngày. \nSau một tháng, cân nặng giảm còn 47 kg nhưng tỷ lệ mỡ cao hơn so với cơ bắp nên cô gái chưa hài lòng. Sợ bị tăng cân trở lại, Huỳnh tiếp tục nhịn ăn, ép bản thân tập luyện cường độ lớn. Sau khoảng thời gian liên tục cắt giảm một số nhóm chất, Huỳnh mắc chứng rối loạn ăn uống, biểu hiện ngay cả khi no, cô vẫn ăn vô độ. \nTôi cảm thấy tội lỗi với cơ thể, nhiều lần cố nôn hết thức ăn ra\", Huỳnh nói, thêm rằng hậu quả sau một năm, cân nặng tăng giảm liên tục, mất kinh nguyệt, tụt huyết áp, mệt mỏi và căng thẳng. \nNhiều nghiên cứu đã chứng minh tác hại của việc nhịn ăn với cơ thể. Theo Healthline, khi thường xuyên bị bỏ đói, cơ thể hoạt động kém hiệu quả do không đủ năng lượng, chức năng sẽ bị hạn chế, gây rụng tóc, rối loạn giấc ngủ, suy giảm trí nhớ, loét dạ dày, hạ đường huyết. Ngoài ra, việc cắt giảm đột ngột những món ăn yêu thích dễ dẫn đến căng thẳng, ảnh hưởng sức khỏe tinh thần.", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1380), true, "TÂY NINHHuỳnh, 22 tuổi, giảm 10 kg trong 6 tháng nhờ duy trì chế độ ăn cầu vồng với đầy đủ nhóm chất, đa dạng màu sắc từ rau củ quả.", "Giảm 10 kg nhờ lối sống lành mạnh", "giam-10-kg-nho-loi-song-lanh-manh" }
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { 1, "Cong1", "comment test 1", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1466), "Cong1@gmail.com", "Cong1", 1 },
                    { 2, "Cong2", "comment test 2", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1468), "Cong2@gmail.com", "Cong2", 2 },
                    { 3, "Cong1", "comment test 3", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1469), "Cong3@gmail.com", "Cong3", 3 },
                    { 4, "Cong4", "comment test 4", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1470), "Cong4@gmail.com", "Cong4", 4 },
                    { 5, "Cong5", "comment test 5", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1471), "Cong5@gmail.com", "Cong5", 5 },
                    { 6, "Cong6", "comment test 6", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1472), "Cong6@gmail.com", "Cong6", 6 },
                    { 7, "Cong7", "comment test 7", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1473), "Cong7@gmail.com", "Cong7", 7 },
                    { 8, "Cong8", "comment test 8", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1474), "Cong8@gmail.com", "Cong8", 8 },
                    { 9, "Cong9", "comment test 9", new DateTime(2023, 8, 21, 23, 22, 40, 394, DateTimeKind.Local).AddTicks(1475), "Cong9@gmail.com", "Cong9", 9 }
                });

            migrationBuilder.InsertData(
                table: "PostTagMap",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { 1, 10 },
                    { 1, 11 },
                    { 2, 8 },
                    { 2, 9 },
                    { 3, 7 },
                    { 4, 6 },
                    { 5, 5 },
                    { 6, 4 },
                    { 7, 3 },
                    { 8, 2 },
                    { 9, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_PostId",
                table: "Comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMap_TagId",
                table: "PostTagMap",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "PostTagMap");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
