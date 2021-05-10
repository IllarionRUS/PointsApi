Mongo Shell команды:

Подключаемся к БД(будет создана если не существует)
use PointstoreDb

Создаем коллекции
db.createCollection('Orders')
db.createCollection('Points')

Добавляем точки доставки
db.Points.insertMany([{'_id':'PT-0001','Address':'Address1','Status':true},{'_id':'PT-0002','Address':'Address2','Status':false},{'_id':'PT-0003','Address':'Address3','Status':true},{'_id':'PT-0004','Address':'Address4','Status':true},{'_id':'PT-0005','Address':'Address5'}])

Api запросы
https://localhost:44394/api/points
https://localhost:44394/api/points/PT-0001
https://localhost:44394/api/orders/

Cоздание заказа
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