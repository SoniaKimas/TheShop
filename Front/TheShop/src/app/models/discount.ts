
export class Discount {
  id: number;
  type: string;
  productId: string;
  sourceProductId?: string;
  sourceRequiredQuantity: number;
  percentage: number;
  startDate: Date;
  endDate: Date;

  constructor(
    id: number,
    type: string,
    productId: string,
    sourceProductId: string | undefined,
    sourceRequiredQuantity: number,
    percentage: number,
    startDate: Date,
    endDate: Date
  ) {
    this.id = id;
    this.type = type;
    this.productId = productId;
    this.sourceProductId = sourceProductId;
    this.sourceRequiredQuantity = sourceRequiredQuantity;
    this.percentage = percentage;
    this.startDate = startDate;
    this.endDate = endDate;
  }
}
