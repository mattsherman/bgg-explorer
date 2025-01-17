import { useEffect, useRef, useState } from 'react';

type LazyLoadingImageProps = {
  src: string;
  alt?: string;
  className?: string;
};

export function LazyLoadedImage({
  src,
  alt,
  className,
}: LazyLoadingImageProps) {
  const [becameVisible, setBecameVisible] = useState(false);
  const imgRef = useRef<HTMLImageElement>(null);

  useEffect(() => {
    const observer = new IntersectionObserver(
      ([entry]) => {
        if (entry.isIntersecting) {
          setBecameVisible(true);
          observer.disconnect();
        }
      },
      {
        threshold: 0,
      }
    );

    const currentImgRef = imgRef.current;

    if (currentImgRef) {
      observer.observe(currentImgRef);
    }

    return () => {
      if (currentImgRef) {
        observer.unobserve(currentImgRef);
      }
    };
  }, []);

  return (
    <img
      ref={imgRef}
      src={becameVisible ? src : ''}
      loading="lazy"
      alt={alt}
      className={className}
    />
  );
}
