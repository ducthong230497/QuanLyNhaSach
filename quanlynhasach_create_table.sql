create database quanlynhasach;
create table SACH
(
	MaSach char(10) not null,
    TenSach varchar(50),
    TheLoai varchar(20),
    TacGia varchar(20),
    SoLuongTon integer,
    DonGia decimal,
    primary key (MaSach)
);

create table PHIEUNHAP
(
	MaPhieuNhap CHAR(10) not null,
    NgayNhap DATETIME,
    PRIMARY KEY(MaPhieuNhap)
);

create table KHACHHANG
(
	MaKhachHang char(10) not null,
    HoTenKhachHang varchar(50),
    DiaChi varchar(100),
    DienThoai char(11),
    Email varchar(50),
    SoTienNo decimal,
    primary key(MaKhachHang)
);

create table THAMSO
(
	SoLuongNhapToiThieu int,
    SoLuongTonToiDaDuocPhepNhap int,
    SoLuongTonToiThieuSauKhiBan int,
    SoTienNoToiDa decimal,
    SuDungQuyDinh4 bool
);

create table CHITIETPHIEUNHAP
(
	MaChiTietPhieuNhap char(10) not null,
    MaPhieuNhap char(10),
    MaSach char(10),
    SoLuongNhap integer,
    
    primary key(MaChiTietPhieuNhap),
    foreign key(MaPhieuNhap) references PHIEUNHAP(MaPhieuNhap),
    foreign key(MaSach) references SACH(MaSach)
);

create table HOADON
(
	MaHoaDon char(10) not null primary key,
    MaKhachHang char(10) ,
    NgayLapHoaDon datetime,
    TongTien decimal,
    foreign key(MaKhachHang) references KHACHHANG(MaKhachHang)
);

create table CHITIETHOADON
(
	MaChiTietHoaDon char(10) primary key,
    MaHoaDon char(10),
    MaSach char(10),
    SoLuongBan integer,
    ThanhTien decimal,
    foreign key(MaHoaDon) references HOADON(MaHoaDon),
    foreign key(MaSach) references SACH(MaSach)
);


create table PHIEUTHUTIEN
(
	MaPhieuThu char(10) primary key,
    SoTienThu decimal,
    NgayThuTien datetime,
    MaKhachHang char(10),
	foreign key(MaKhachHang) references KHACHHANG(MaKhachHang)
);

create table BAOCAOTON
(
	MaBaoCaoTon char(10) primary key,
	Thang integer,
	Nam integer
);

create table CHITIETTON
(
	MaChiTietTon char(10) primary key,
    MaBaoCaoTon char(10),
    MaSach char(10),
    TonDau int,
    TonPhatSinh int,
    TonCuoi int,
    foreign key(MaBaoCaoTon) references baocaoton(MaBaoCaoTon),
    foreign key(MaSach) references sach(MaSach)
);

create table BAOCAOCONGNO
(
	MaBaoCaoCongNo char(10) primary key,
    Thang char(30),
	Nam integer
);

create table CHITIETCONGNO
(
	MaChiTietCongNo char(10) primary key,
    MaBaoCaoCongNo char(10),
    MaKhachHang char(10),
    NoDau decimal,
    NoPhatSinh decimal,
    NoCuoi decimal,
    foreign key(MaKhachHang) references khachhang(MaKhachHang),
    foreign key(MaBaoCaoCongNo) references baocaocongno(MaBaoCaoCongNo)
);

create table KHACHHANGDAXOA
(
	MaKhachHangDaXoa char(10) primary key
);

create table SACHDAXOA
(
	MaSachDaXoa char(10) primary key
);

create table CHITIETBAOCAOTON
(
	MaChiTietTon char(10) primary key,
    MaBaoCaoTon char(10),
    MaSach char(10),
    TonDau int,
    TonPhatSinh int,
    TonCuoi int,
    foreign key(MaBaoCaoTon) references baocaoton(MaBaoCaoTon),
    foreign key(MaSach) references sach(MaSach)
);

create table CHITIETBAOCAOCONGNO
(
	MaChiTietCongNo char(10) primary key,
    MaBaoCaoCongNo char(10),
    MaKhachHang char(10),
    NoDau decimal,
    NoPhatSinh decimal,
    NoCuoi decimal,
    foreign key(MaBaoCaoCongNo) references baocaocongno(MaBaoCaoCongNo),
    foreign key(MaKhachHang) references khachhang(MaKhachHang)
)
drop table CHITIETBAOCAOCONGNO;
drop table CHITIETBAOCAOTON;

insert into sach values('MS0000', '0', '0', '0', 0, 50000);
insert into sach values('MS0001', '1', '1', '1', 0, 50000);
insert into sach values('MS0002', '2', '2', '2', 0, 50000);
insert into sach values('MS0003', '3', '3', '3', 0, 50000);
insert into sach values('MS0004', '4', '4', '4', 0, 50000);
insert into sach values('MS0005', '5', '5', '5', 0, 50000);
insert into sach values('MS0006', '6', '6', '6', 0, 50000);
insert into sach values('MS0007', '7', '7', '7', 0, 50000);
insert into sach values('MS0008', '8', '8', '8', 0, 50000);
insert into sach values('MS0009', '9', '9', '9', 0, 50000);
insert into sach values('MS0010', '10', '10', '10', 100, 50000);

insert into khachhang values('KH0000', '0', '0', '0', '0@0.com', 0);
insert into khachhang values('KH0001', '1', '1', '1', '1@1.com', 0);
insert into khachhang values('KH0002', '2', '2', '2', '2@2.com', 0);
insert into khachhang values('KH0003', '3', '3', '3', '3@3.com', 0);
insert into khachhang values('KH0004', '4', '4', '4', '4@4.com', 0);
insert into khachhang values('KH0005', '5', '5', '5', '5@5.com', 0);
insert into khachhang values('KH0006', '6', '6', '6', '6@6.com', 0);
insert into khachhang values('KH0007', '7', '7', '7', '7@7.com', 0);
insert into khachhang values('KH0008', '8', '8', '8', '8@8.com', 0);
insert into khachhang values('KH0009', '9', '9', '9', '9@9.com', 0);
insert into khachhang values('KH0010', '10', '10', '10', '10@10.com', 0);

insert into thamso values(150, 300, 20, 200000, 1)


select * from thamso
SELECT DATE_FORMAT(NgayNhap, '%d/%m/%Y') FROM phieunhap
insert into phieunhap (MaPhieuNhap, NgayNhap) values ('MS2', curdate())
select * from sach where TenSach like 'a%'
select * from phieunhap
select * from chitietphieunhap
insert into khachhang values('KH0001', 'adsl', 'aaaaa', '123','@', 500000)
select * from khachhang
select HoTenKhachHang, SoTienNo from khachhang where MaKhachHang = 'KH0002'
select * from hoadon
select * from chitiethoadon
select TenSach from sach where MaSach = 'MS0001'
select * from baocaoton
select * from 	Sach where MaSach like '%%' and TenSach like '%%' and TheLoai like '%%' and 
				TacGia like '%%' and (SoLuongTon >= 200 and SoLuongTon <= 300) and 
                (DonGia >= 0 and DonGia <= 300) and MaSach not in
                (select * from SachDaXoa)

select chitietton.MaSach, chitietton.TonDau, chitietton.TonPhatSinh, chitietton.TonCuoi 
from baocaoton join chitietton on baocaoton.MaBaoCaoTon = chitietton.MaBaoCaoTon 
where baocaoton.Thang = 6 and baocaoton.Nam = 2017

select chitietcongno.MaKhachHang, chitietcongno.NoDau, chitietcongno.NoPhatSinh, chitietcongno.NoCuoi 
from baocaocongno join chitietcongno on baocaocongno.MaBaoCaoCongNo = chitietcongno.MaChiTietCongNo 
where Thang = 6 and Nam = 2017

select s.MaSach, s.TenSach, c.TonDau, c.TonPhatSinh, c.TonCuoi
from baocaoton as b join chitietton as c on b.MaBaoCaoTon = c.MaBaoCaoTon 
					join sach as s on c.MaSach = s.MaSach
where b.Thang = 6 and b.Nam = 2017                    
                    
select k.MaKhachHang, k.HoTenKhachHang, c.NoDau, c.NoPhatSinh, c.NoCuoi
from baocaocongno b join chitietcongno c on b.MaBaoCaoCongNo = c.MaBaoCaoCongNo
					join khachhang k on k.MaKhachHang = c.MaKhachHang
where b.Thang = 6 and b.Nam = 2017                    




                    