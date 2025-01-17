export type Item = {
  objectId: number;
  collectionId: number;
  name: string;
  yearPublished: number;
  thumbnail: string;
  image: string;
};

export type Collection = {
  count: number;
  items: Item[];
};
