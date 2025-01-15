import { useEffect, useState } from 'react';
import './App.css';

import { ItemsList } from './components/ItemsList';
import { Collection } from './types';

function App() {
  const [collection, setCollection] = useState<Collection | undefined>();

  useEffect(() => {
    (async () => {
      const res = await fetch(
        'http://localhost:5005/users/mattsherman/collection'
      );
      const json = await res.json();
      setCollection(json);
    })();
  }, []);

  return (
    <>
      <ItemsList items={collection?.items} />
    </>
  );
}

export default App;
