# ElevatorSystem-ToangCSharp

  #Note các bước thiết kế tại đây

1. Tag :
Xu ly CreatedDate chua hop ly

2. Category : 
Xu ly CreatedDate chua hop ly


3. Blog :  trang Index + chua show dc anh
Create : 
         chua upload dc anh
Update: 
         chua upload dc anh
Delete : Chua co anh
Detail : Chua co anh

4. Product : chua co
Craete : Tag - multi string
         Thumbnails - mutil pics
         Dinh dang lai trang inout tag
Update : chua co anh + Tag + dinh dang Tag + Status fail
Delte : chua co
Index : chua co
Detai: 

5. Order : Check lại OrderCOntroller xem có lỗi j ko

[HttpPost]
        public string UploadImages(HttpPostedFileBase file)
        {
            Random r = new Random();
            int num = r.Next();

            file.SaveAs(Server.MapPath("~/Content/Elevator/") + num + "_" + file.FileName);
            return "/Content/Elevator/" + num + "_" + file.FileName;
        }

[HttpPost]
        public JsonResult Create( Elevator elevator)
        {
            if (ModelState.IsValid)
            {
                db.Elevators.Add(elevator);
                db.SaveChanges();
            }

           // ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", elevator.CategoryID);
            return Json(elevator, JsonRequestBehavior.AllowGet);
        }


bang user trong DB la model nao
Khong cho xoa Category khi vx con Product
XU ly cac ham ben controller



0-pending
1-processing
2-complete
3-cancel
