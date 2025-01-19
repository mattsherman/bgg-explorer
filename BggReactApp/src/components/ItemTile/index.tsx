import type { Item } from '../../types';
import { LazyLoadedImage } from '../LazyLoadedImage';

import classes from './index.module.css';

type ItemTileProps = {
  item: Item;
};

export function ItemTile({ item }: ItemTileProps) {
  return (
    <a href={item.pageUrl} target="_blank" className={classes['item-tile']}>
      <figure>
        <LazyLoadedImage
          src={item.thumbnail}
          className={classes['thumbnail']}
        />
        <figcaption className={classes['name']}>
          {item.name} ({item.yearPublished})
        </figcaption>
      </figure>
    </a>
  );
}
