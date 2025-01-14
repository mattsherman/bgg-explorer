import { useEffect, useState } from 'react';
import './App.css';

function App() {
  const [collection, setCollection] = useState(null);

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
      <ul>
        {collection &&
          collection.items.map((item: any) => (
            <li key={item.objectId}>
              {item.name} ({item.yearPublished})
            </li>
          ))}
      </ul>
    </>
  );
}

export default App;
