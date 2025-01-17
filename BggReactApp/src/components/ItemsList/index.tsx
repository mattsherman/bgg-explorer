import type { Item } from '../../types';
import { ItemTile } from '../ItemTile';

import classes from './index.module.css';

type ItemsListProps = {
  items?: Item[];
};

export function ItemsList({ items }: ItemsListProps) {
  return (
    <ul className={classes['items-list']}>
      {items?.map((item) => (
        <li key={item.collectionId}>
          <ItemTile item={item} />
        </li>
      ))}
    </ul>
  );
}
