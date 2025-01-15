import type { Item } from '../types';
import { ItemTile } from './ItemTile';

type ItemsListProps = {
  items?: Item[];
};

export function ItemsList({ items }: ItemsListProps) {
  return (
    <ul>
      {items?.map((item) => (
        <li key={item.objectId}>
          <ItemTile item={item} />
        </li>
      ))}
    </ul>
  );
}
