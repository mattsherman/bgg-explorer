import { useEffect, useState } from 'react';
import { useParams } from 'react-router';

import { ItemsList } from '../../components/ItemsList';
import { Collection } from '../../types';

export function UserCollection() {
  const [collection, setCollection] = useState<Collection | undefined>();
  const params = useParams();

  useEffect(() => {
    setCollection(undefined);

    (async () => {
      const res = await fetch(
        `http://localhost:5005/users/${params.username}/collection`
      );
      const json = await res.json();
      setCollection(json);
    })();
  }, [params.username]);

  return <ItemsList items={collection?.items} />;
}
