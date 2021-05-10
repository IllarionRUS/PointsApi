Mongo Shell �������:

������������ � ��(����� ������� ���� �� ����������)
use PointstoreDb

������� ���������
db.createCollection('Orders')
db.createCollection('Points')

��������� ����� ��������
db.Points.insertMany([{'_id':'PT-0001','Address':'Address1','Status':true},{'_id':'PT-0002','Address':'Address2','Status':false},{'_id':'PT-0003','Address':'Address3','Status':true},{'_id':'PT-0004','Address':'Address4','Status':true},{'_id':'PT-0005','Address':'Address5'}])

Api �������
https://localhost:44394/api/points
https://localhost:44394/api/points/PT-0001
https://localhost:44394/api/orders/

C������� ������
https://localhost:44394/api/orders
Body
{'Id':'1112',
'Status': 1,
'OrderList': ['One', 'two', 'three', 'four', 'five', 'Six', 'seven', 'eight', 'nine', 'ten'],
'OrderPrice': 49.99,
'PointNumber':'PT-0001',
'RecepientPhone':'+7123-123-11-22',
'RecepientName':'Recepient',
}