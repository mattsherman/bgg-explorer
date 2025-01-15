import type { Item } from '../types';

export function ItemTile({ item }: { item: Item }) {
  return (
    <figure>
      <img src={item.thumbnail} alt={item.name} />
      <figcaption>
        {item.name} ({item.yearPublished})
      </figcaption>
    </figure>
  );
}
