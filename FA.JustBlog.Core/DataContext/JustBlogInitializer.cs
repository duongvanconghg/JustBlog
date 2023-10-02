using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.DataContext
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Categories>().HasData(
                new Categories
                {
                    Id = 1,
                    Name = "Thể thao",
                    Description = "thể thao",
                    UrlSlug = "the-thao",
                },
                new Categories
                {
                    Id = 2,
                    Name = "Giáo dục",
                    Description = "Giáo dục",
                    UrlSlug = "giao-duc"
                },  
                new Categories
                {
                    Id = 3,
                    Name = "Sức khỏe",
                    Description = "Sức khỏe",
                    UrlSlug = "suc-khoe"
                }
            );

            builder.Entity<Posts>().HasData(
                new Posts
                {
                    Id = 1,
                    Title = "Việt Nam có vé thứ hai dự Olympic Paris 2024",
                    ShortDescription = "Sau cua-rơ Nguyễn Thị Thật, xạ thủ Trịnh Thu Vinh trở thành VĐV Việt Nam thứ hai có vé đến Olympic Paris 2024.",
                    PostContent = "Trịnh Thu Vinh giành vé nhờ thành tích tại giải VĐTG (ISSFWC) 2023 tổ chức tại Baku, Azerbaijan. Xạ thủ này tham dự nội dung 10m súng ngắn hơi nữ trong ngày khai mạc hôm nay 17/8. \n" +
                    "Ở vòng loại, Thu Vinh đạt 579 điểm để xếp thứ năm, qua đó vào nhóm tám xạ thủ thi chung kết. Phần thi chung kết bắt đầu loại dần VĐV từ lượt bắn thứ tư, và Thu Vinh trụ đến loạt thứ sáu với 175,6 điểm." +
                    "Xạ thủ Trung Quốc Jiang Ranxin giành HC vàng với 239,8 điểm sau tám loạt bắn. Xếp sau lần lượt là VĐV Hy Lạp Korakaki Anna - 238,3 điểm, VĐV Trung Quốc Li Xue - 218,9 điểm, và VĐV Hungary Fabian Sara Rahel - 198,9 điểm.",
                    UrlSlug = "the-thao",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                },
                new Posts
                {
                    Id = 2,
                    Title = "VFF cấm thi đấu hai năm thủ môn giải hạng Nhì",
                    ShortDescription = "Thủ môn Nguyễn Văn Bá của Kiên Giang bị cấm thi đấu kịch khung do thi đấu tiêu cực ở vòng 13 bảng B giải hạng Nhì 2023.",
                    PostContent = "Ngày 30/7, Kiên Giang thua 0-6 Đồng Nai trên sân nhà. Thủ môn Nguyễn Văn Bá thủng lưới năm bàn trong hiệp hai và phải nhận hai thẻ vàng liên tiếp từ trọng tài chính ở phút 90 và phút bù thứ nhất.\r\n\r\n" +
                    "Sau khi nhận báo cáo từ giám sát trận đấu Nguyễn Tấn Long, trọng tài Nguyễn Kim Việt Bảo, Ban kỷ luật VFF xác định thủ môn Nguyễn Văn Bá cố tình buông xuôi để thua thêm bàn.\r\n\r\n" +
                    "Ngày 18/8, Ban kỷ luật VFF quyết định phạt Nguyễn Văn Bá 10 triệu đồng và cấm tham gia hoạt động bóng đá 24 tháng tại các giải do VFF quản lý, tổ chức. Nguyễn Văn Bá được xác định vi phạm Điều 52 về dàn xếp trận đấu, tỷ số, cụ thể thi đấu không đúng khả năng và làm sai lệch kết quả trận đấu.",
                    UrlSlug = "vff-cam-thi-dau-hai-nam-thu-mon-giai-hang-nhi",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                },
                new Posts
                {
                    Id = 3,
                    Title = "Quế Ngọc Hải chia tay SLNA",
                    ShortDescription = "Trung vệ thủ quân Quế Ngọc Hải xin thanh lý hợp đồng trước thời hạn một năm và nhận được sự đồng ý của lãnh đạo CLB SLNA.",
                    PostContent = "Hôm 15/8, Quế Ngọc Hải đã gặp Chủ tịch CLB SLNA Trương Sỹ Bá, đề đạt nguyện vọng được ra đi dù hợp đồng còn thời hạn đến hết năm 2024." +
                    "Lãnh đạo đội bóng xứ Nghệ chấp thuận, thậm chí không đòi lại khoản tiền lót tay còn lại trong các tháng cuối năm 2023. Ngọc Hải đang chờ giấy thanh lý hợp đồng. Anh hiện nhận được sự quan tâm từ CLB Hà Tĩnh và Nam Định.\r\n\r\n" +
                    "Quế Ngọc Hải sinh năm 1993, trưởng thành từ lò đào tạo SLNA, lên chơi cho đội một năm 2012. Anh chơi cho đội bóng xứ Nghệ sáu mùa, từng được đeo băng đội trưởng trước khi gia nhập Viettel năm 2018.\r\n\r\n",
                    UrlSlug = "que-ngoc-hai-chia-tay-slna",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 1,
                },
                new Posts
                {
                    Id = 4,
                    Title = "Đại học gặp thách thức rất lớn về tài chính khi tự chủ",
                    ShortDescription = "Ông Vũ Hải Quân, Giám đốc Đại học Quốc gia TP HCM, cho rằng tự chủ đại học ở Việt Nam gặp thách thức rất lớn về tài chính, với cả cơ sở đào tạo và người học.",
                    PostContent = "Tại hội nghị Tổng kết năm học 2022-2023 và triển khai nhiệm vụ năm học 2023-2024 do Bộ Giáo dục và Đào tạo tổ chức chiều 18/8, PGS.TS Vũ Hải Quân cho biết tự chủ đại học ghi nhận nhiều kết quả tích cực. \n" +
                    "Như tại Đại học Quốc gia TP HCM, 6 trường thành viên đã tự chủ chi thường xuyên (chi lương, phụ cấp, dịch vụ công cộng, sửa chữa tài sản...). Trường nằm trong top 1.000 đại học hàng đầu thế giới, 126 chương trình đào tạo đã đạt chuẩn kiểm định quốc tế. Năm ngoái, Đại học Quốc gia TP HCM công bố gần 2.400 bài báo quốc tế trong danh mục Scopus, chiếm hơn 12% tổng số công bố của cả nước. \n" +
                    "Tuy nhiên, ông Quân nhìn nhận tiến trình tự chủ đại học ở Việt Nam thời gian qua gặp thách thức rất lớn như: nguồn thu chủ yếu dựa vào học phí; chính sách cho sinh viên vay còn rất hạn chế, cả về diện được vay lẫn quy trình thủ tục, định mức và thời hạn vay; một số quy định về pháp luật chưa đồng bộ, chưa thúc đẩy tự chủ đại học; mất cân đối trong lĩnh vực ngành nghề đào tạo khi ít sinh viên chọn ngành khoa học, kỹ thuật công nghệ.",
                    UrlSlug = "dai-hoc-gap-thach-thuc-rat-lon-ve-tai-chinh-khi-tu-chu",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                },
                new Posts
                {
                    Id = 5,
                    Title = "Nên chọn Tự động hóa, Điện tử viễn thông hay Khoa học máy tính?",
                    ShortDescription = "Em khá thích lập trình, chế tạo các loại máy móc, thiết bị nhưng chưa biết chọn Tự động hóa, Điện tử viễn thông hay Khoa học máy tính.",
                    PostContent = "Theo em tìm hiểu, giáo trình của ba ngành này đều dạy lập trình. Khoa học máy tính có vẻ dạy lập trình nhiều nhất, Tự động hóa ít nhất." +
                    "Ban đầu em phân vân giữa Điện tử viễn thông và Tự động hóa, nhưng giờ nghe mọi người bảo cơ hội việc làm của Khoa học máy tính tốt hơn, em khá đắn đo. Nhờ mọi người tư vấn giúp em về môi trường làm việc, lương và các công việc phù hợp với mỗi ngành sau tốt nghiệp ạ. \n" +
                    "",
                    UrlSlug = "nen-chon-tu-dong-hoa-dien-tu-vien-thong-hay-khoa-hoc-may-tinh",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                },
                new Posts
                {
                    Id = 6,
                    Title = "Hà Nội có thể thêm hai trường chuyên",
                    ShortDescription = "Sở Giáo dục và Đào tạo Hà Nội dự kiến xây dựng đề án, chuyển trường THPT Chu Văn An và Sơn Tây thành trường chuyên.",
                    PostContent = "Thông tin được đưa ra tại Hội nghị triển khai nhiệm vụ năm học mới bậc THCS của Sở Giáo dục và Đào tạo Hà Nội, chiều 18/8. Lãnh đạo Sở cho hay theo quy chế hoạt động trường THPT chuyên, Bộ Giáo dục và Đào tạo yêu cầu không tổ chức lớp không chuyên trong trường chuyên. \n" +
                    "Trong khi đó, hiện hai trường THPT Chu Văn An (quận Tây Hồ) và THPT Sơn Tây (thị xã Sơn Tây) tồn tại cả mô hình lớp chuyên và không chuyên. Do đó, Sở dự kiến xây dựng đề án, chuyển hai trường này thành trường chuyên. \n" +
                    "Trước dự kiến này, đại diện Phòng Giáo dục và Đào tạo thị xã Sơn Tây bày tỏ băn khoăn vì hiện trên địa bàn có ít trường THPT công lập. Nếu THPT Sơn Tây chuyển thành trường chuyên thì chỉ tiêu cho hệ thường không còn. \n",
                    UrlSlug = "ha-noi-co-the-them-hai-truong-chuyen",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 2,
                },
                new Posts
                {
                    Id = 7,
                    Title = "Cơn đau do sỏi thận",
                    ShortDescription = "Viên sỏi rơi từ thận xuống đường tiết niệu, làm tắc nghẽn đường tiểu, gây ra cơn đau đột ngột, tăng dần, kéo dài nhiều giờ.",
                    PostContent = "BS.CKII Đinh Cẩm Tú, Trưởng Đơn vị Thận nhân tạo, Trung tâm Tiết niệu - Thận học - Nam khoa, Bệnh viện Đa khoa Tâm Anh TP HCM, cho biết sỏi thận là nguyên nhân chính gây ra cơn đau quặn thận (cơn đau bão thận). \n" +
                    "Sỏi di chuyển theo chiều xuôi, từ thận qua bàng quang đến niệu đạo để đào thải khỏi cơ thể. Nếu sỏi mắc kẹt trong đường tiết niệu, cản trở dòng nước tiểu. Ngoài gây đau, bế tắc đường tiểu, tình trạng này còn làm tăng áp lực và viêm nhiễm hệ tiết niệu \n" +
                    "Vị trí đau phụ thuộc vào vị trí và sự di chuyển của sỏi trong hệ tiết niệu. Triệu chứng điển hình của cơn đau bão thận là đau dữ dội, đột ngột khởi phát từ mạn sườn một bên, lan đến giữa xương sườn dưới và hông. Cơn đau có thể lan ra lưng, bụng dưới hoặc hướng về bẹn. Đau xuất hiện thành từng đợt, thường kèm theo buồn nôn. \n" +
                    "Các triệu chứng khác như lượng nước tiểu ít hơn bình thường, đi tiểu gấp, đau khi đi tiểu, có máu trong nước tiểu, nước tiểu đục, có mùi hôi... Người bệnh có thể bị sốt kèm ớn lạnh.",
                    UrlSlug = "con-dau-do-soi-than",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                },
                new Posts
                {
                    Id = 8,
                    Title = "Ăn gì giảm ngứa da?",
                    ShortDescription = "Cá béo, trái cây chứa vitamin C, E và quercetin có khả năng chống viêm, hỗ trợ giảm ngứa khi da bị kích ứng.",
                    PostContent = "Theo Hiệp hội Da liễu Mỹ (AAD), da ngứa có thể do khô, dị ứng, ký sinh trùng, vết côn trùng cắn, bệnh vẩy nến, viêm da dị ứng. Nguyên nhân nghiêm trọng khác như bệnh thận, tiểu đường, HIV. \n" +
                    "Hầu hết trường hợp có thể dùng thuốc để giảm ngứa. Chế độ ăn cũng góp phần cải thiện tình trạng, ngăn ngừa các vấn đề kích ứng da khác.",
                    UrlSlug = "an-gi-giam-ngua-da",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                },
                new Posts
                {
                    Id = 9,
                    Title = "Giảm 10 kg nhờ lối sống lành mạnh",
                    ShortDescription = "TÂY NINHHuỳnh, 22 tuổi, giảm 10 kg trong 6 tháng nhờ duy trì chế độ ăn cầu vồng với đầy đủ nhóm chất, đa dạng màu sắc từ rau củ quả.",
                    PostContent = "Nguyễn Thị Tuyết Huỳnh, cao 1,63 m, từng nặng 62 kg, tìm đến nhiều phương pháp giảm cân cực đoan như nhịn ăn, tập luyện cường độ cao, kèm thuốc giảm cân. Mỗi bữa, cô ăn rất ít, chủ yếu là ức gà và rau luộc, loại bỏ hoàn toàn tinh bột, ép bản thân tập thể dục 3-4 tiếng một ngày. \n" +
                    "Sau một tháng, cân nặng giảm còn 47 kg nhưng tỷ lệ mỡ cao hơn so với cơ bắp nên cô gái chưa hài lòng. Sợ bị tăng cân trở lại, Huỳnh tiếp tục nhịn ăn, ép bản thân tập luyện cường độ lớn. Sau khoảng thời gian liên tục cắt giảm một số nhóm chất, Huỳnh mắc chứng rối loạn ăn uống, biểu hiện ngay cả khi no, cô vẫn ăn vô độ. \n" +
                    "Tôi cảm thấy tội lỗi với cơ thể, nhiều lần cố nôn hết thức ăn ra\", Huỳnh nói, thêm rằng hậu quả sau một năm, cân nặng tăng giảm liên tục, mất kinh nguyệt, tụt huyết áp, mệt mỏi và căng thẳng. \n" +
                    "Nhiều nghiên cứu đã chứng minh tác hại của việc nhịn ăn với cơ thể. Theo Healthline, khi thường xuyên bị bỏ đói, cơ thể hoạt động kém hiệu quả do không đủ năng lượng, chức năng sẽ bị hạn chế, gây rụng tóc, rối loạn giấc ngủ, suy giảm trí nhớ, loét dạ dày, hạ đường huyết. Ngoài ra, việc cắt giảm đột ngột những món ăn yêu thích dễ dẫn đến căng thẳng, ảnh hưởng sức khỏe tinh thần.",
                    UrlSlug = "giam-10-kg-nho-loi-song-lanh-manh",
                    Published = true,
                    PostedOn = DateTime.Now,
                    Modified = DateTime.Now,
                    CategoryId = 3,
                }
            );

            builder.Entity<Tags>().HasData(
                new Tags
                {
                    Id = 1,
                    Name = "Giảm cân",
                    Description = "Giảm cân",
                    Count = 1,
                    UrlSlug = "giam-can"
                },
                new Tags
                {
                    Id = 2,
                    Name = "Dị ứng",
                    Description = "Dị ứng",
                    Count = 1,
                    UrlSlug = "di-ung"
                },
                new Tags
                {
                    Id = 3,
                    Name = "Sỏi thận",
                    Description = "Sỏi thận",
                    Count = 1,
                    UrlSlug = "soi-than"
                },
                new Tags
                {
                    Id = 4,
                    Name = "Trường chuyên",
                    Description = "Trường chuyên",
                    Count = 1,
                    UrlSlug = "truong-chuyen"
                },
                new Tags
                {
                    Id = 5,
                    Name = "Công nghệ",
                    Description = "Công nghệ",
                    Count = 1,
                    UrlSlug = "cong-nghe"
                },
                new Tags
                {
                    Id = 6,
                    Name = "Đại học",
                    Description = "Đại học",
                    Count = 1,
                    UrlSlug = "dai-hoc"
                },
                new Tags
                {
                    Id = 7,
                    Name = "Bóng đá",
                    Description = "Bóng đá",
                    Count = 1,
                    UrlSlug = "bong-da"
                },
                new Tags
                {
                    Id = 8,
                    Name = "Bóng đá",
                    Description = "Bóng đá",
                    Count = 1,
                    UrlSlug = "bong-da",
                },
                new Tags
                {
                    Id = 9,
                    Name = "VFF",
                    Description = "VFF",
                    Count = 1,
                    UrlSlug = "VFF"
                },
                new Tags
                {
                    Id = 10,
                    Name = "Xạ thủ",
                    Description = "Xạ thủ",
                    Count = 1,
                    UrlSlug = "xa-thu"
                },
                new Tags
                {
                    Id = 11,
                    Name = "Olympic Paris 2024",
                    Description = "Olympic Paris 2024",
                    Count = 1,
                    UrlSlug = "olympic-paris-2024"
                }
            );

            builder.Entity<PostTagMap>().HasData(
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 11,
                },
                new PostTagMap
                {
                    PostId = 1,
                    TagId = 10,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 9,
                },
                new PostTagMap
                {
                    PostId = 2,
                    TagId = 8,
                },
                new PostTagMap
                {
                    PostId = 3,
                    TagId = 7,
                },
                new PostTagMap
                {
                    PostId = 4,
                    TagId = 6,
                },
                new PostTagMap
                {
                    PostId = 5,
                    TagId = 5,
                },
                new PostTagMap
                {
                    PostId = 6,
                    TagId = 4,
                },
                new PostTagMap
                {
                    PostId = 7,
                    TagId = 3,
                },
                new PostTagMap
                {
                    PostId = 8,
                    TagId = 2,
                },
                new PostTagMap
                {
                    PostId = 9,
                    TagId = 1,
                }
            );

            builder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Name = "Cong1",
                    Email = "Cong1@gmail.com",
                    PostId = 1,
                    CommentHeader = "Cong1",
                    CommentText = "comment test 1",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 2,
                    Name = "Cong2",
                    Email = "Cong2@gmail.com",
                    PostId = 2,
                    CommentHeader = "Cong2",
                    CommentText = "comment test 2",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 3,
                    Name = "Cong3",
                    Email = "Cong3@gmail.com",
                    PostId = 3,
                    CommentHeader = "Cong1",
                    CommentText = "comment test 3",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 4,
                    Name = "Cong4",
                    Email = "Cong4@gmail.com",
                    PostId = 4,
                    CommentHeader = "Cong4",
                    CommentText = "comment test 4",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 5,
                    Name = "Cong5",
                    Email = "Cong5@gmail.com",
                    PostId = 5,
                    CommentHeader = "Cong5",
                    CommentText = "comment test 5",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 6,
                    Name = "Cong6",
                    Email = "Cong6@gmail.com",
                    PostId = 6,
                    CommentHeader = "Cong6",
                    CommentText = "comment test 6",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 7,
                    Name = "Cong7",
                    Email = "Cong7@gmail.com",
                    PostId = 7,
                    CommentHeader = "Cong7",
                    CommentText = "comment test 7",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 8,
                    Name = "Cong8",
                    Email = "Cong8@gmail.com",
                    PostId = 8,
                    CommentHeader = "Cong8",
                    CommentText = "comment test 8",
                    CommentTime = DateTime.Now
                },
                new Comment
                {
                    Id = 9,
                    Name = "Cong9",
                    Email = "Cong9@gmail.com",
                    PostId = 9,
                    CommentHeader = "Cong9",
                    CommentText = "comment test 9",
                    CommentTime = DateTime.Now
                }
            );
        }
    }
}
