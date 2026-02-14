# FlashSaleApi
This project implements a set of RESTful endpoints for a high-traffic "Flash Sale" system. It manages inventory for a single high-demand product (such as concert tickets or limited-edition sneakers) and ensures that concurrent requests do not oversell available stock.  
The system uses in-memory storage and basic thread-safety mechanisms to simulate real-world concurrency handling.

Features

->Initialize Inventory (Admin)

Sets the total available inventory.

Resets waitlist and reservations.

->Reserve Item

If inventory is available:

Decrements inventory.

Returns a reservation_id and expiry timestamp.

If inventory is sold out:

Adds the user to a waitlist.

Returns waitlist position.

->Status

Returns current available inventory.

Returns current waitlist size.


API Endpoints
1.Initialize Inventory
POST /api/sale/init

Request Body:
{
"count": 100
}

Response:
200 OK
{
"message": "Inventory initialized",
"count": 100
}

2.Reserve Item
POST /api/sale/reserve

Request Body:
{
"user_id": "user_123"
}

Success Response:
201 Created
{
"reservation_id": "res_abc123",
"expires_at": "2026-02-14T10:05:00Z",
"message": "Reserved"
}

Sold Out Response:
202 Accepted
{
"message": "Added to waitlist",
"waitlist_position": 45
}


3.Get status
GET /api/sale/status

Response:
200 OK
{
"available_inventory": 12,
"waitlist_size": 30
}
