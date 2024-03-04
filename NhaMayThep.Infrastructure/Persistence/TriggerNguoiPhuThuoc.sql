CREATE TRIGGER tg_insert_npt
ON dbo.ThongTinGiamTruGiaCanh
AFTER INSERT
AS
BEGIN
UPDATE NhanVien
SET SoNguoiPhuThuoc = SoNguoiPhuThuoc+1
WHERE ID IN (SELECT NhanVienID FROM inserted)
END

CREATE TRIGGER tg_update_npt
ON dbo.ThongTinGiamTruGiaCanh
AFTER UPDATE
AS  
BEGIN
UPDATE NhanVien
SET SoNguoiPhuThuoc = SoNguoiPhuThuoc-1
WHERE ID IN (SELECT NhanVienID FROM inserted)
END

