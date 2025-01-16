import type { Item } from '../../types';

import classes from './index.module.css';

type ItemTileProps = {
  item: Item;
};

export function ItemTile({ item }: ItemTileProps) {
  return (
    <figure className={classes['item-tile']}>
      <img
        src={item.thumbnail}
        alt={item.name}
        className={classes['thumbnail']}
      />
      <figcaption className={classes['name']}>
        {item.name} ({item.yearPublished})
      </figcaption>
    </figure>
  );
}
