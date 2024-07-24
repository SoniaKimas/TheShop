export class Product {
  id: string;
  name: string;
  imageUrl: string;
  price: number;
  unitType?: string;

  constructor(id: string, name: string, imageUrl: string, price: number, unitType?: string) {
    this.id = id;
    this.name = name;
    this.imageUrl = imageUrl;
    this.price = price;
    this.unitType = unitType;
  }
}
