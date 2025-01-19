export type Item = {
  objectId: number;
  collectionId: number;
  name: string;
  yearPublished: number;
  thumbnail: string;
  image: string;
  pageUrl: string;
};

export type Collection = {
  count: number;
  items: Item[];
};
