import { useEffect, useState } from 'react';

import { ItemsList } from '../../components/ItemsList';
import { Collection } from '../../types';

export function HotItems() {
  const [collection, setCollection] = useState<Collection | undefined>();

  useEffect(() => {
    setCollection(undefined);

    (async () => {
      const res = await fetch(`http://localhost:5005/hot-items`);
      const json = await res.json();
      setCollection(json);
    })();
  }, []);

  return <ItemsList items={collection?.items} />;
}
