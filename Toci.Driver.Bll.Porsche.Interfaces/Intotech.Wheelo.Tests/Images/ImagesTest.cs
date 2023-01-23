using Org.BouncyCastle.Utilities.Zlib;
using System.Net.Mime;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Drawing.Processing.Processors.Drawing;
//using SixLabors.Primitives;
//using SixLabors.Shapes;
using Point = SixLabors.ImageSharp.Point;
using Size = SixLabors.ImageSharp.Size;

namespace Intotech.Wheelo.Tests.Images;

[TestClass]
public class ImagesTest
{
    [TestMethod]
    public void MergeImagesTest()
    {
        IImageFormat format;

        byte[] inputStream = Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/7QCcUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAIAcAmcAFE1PZkQyRTFvalVZLUM3a21UX1NtHAIoAGJGQk1EMGEwMDBhODgwMTAwMDBhNzAyMDAwMDNjMDQwMDAwYmIwNDAwMDA0ZjA1MDAwMDRiMDcwMDAwNjQwOTAwMDBiNzA5MDAwMDM1MGEwMDAwYzAwYTAwMDBmYTBkMDAwMP/bAEMABgQFBgUEBgYFBgcHBggKEAoKCQkKFA4PDBAXFBgYFxQWFhodJR8aGyMcFhYgLCAjJicpKikZHy0wLSgwJSgpKP/bAEMBBwcHCggKEwoKEygaFhooKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKP/CABEIAGQAZAMBIgACEQEDEQH/xAAcAAACAgMBAQAAAAAAAAAAAAAABwUGAgMEAQj/xAAZAQADAQEBAAAAAAAAAAAAAAACAwQBAAX/2gAMAwEAAhADEAAAAWoqWsuWKWnvPurTlnzde5KzBb4bF9HMuu6MS7Uc8c70ASFO2FMYL/LGaoVHMKMts1PdN8fBJROR+PR2I36AVTVrl3ACQp2wqDCgyUwHt566JcZKLDx7/VllS7THF0ZfFG3Xq2AcAp2wpjCAtK6u/Fy2iFsCm2GF1TE74SqSq7rnm3ohH4+fYBO0UzZUxgv5WKHKccgnGTDVNrxkxAtU+XvJ6Pnyz7+evoQN3AIoFM2VMYL8B6fejn7s525Y93l38CVfVfpUnfoxFPRydoC2imAwX4D0+zwCTe3B5duqEA8Tn0mF0u4BTf/EACgQAAICAAUDBAIDAAAAAAAAAAIDAQQABRAREgYhNBMUMTMVJCIjMv/aAAgBAQABBQLHV+3u/wCvEcMRwxEBtWlSjJq3rOqAk6kwcdPjztR8adVVoZOGcYnABJFldDkX40djyrYSNtZlWYp5xHxp1j5eiY3bUogMIVxwOJxZULl3lGlqe6tOsfMxXQqVUsoh6UiQz32J7Bmu8m4P4zxHKun6dOsPMHfetY4zlEwdBfY1/DaqiMAgBtqKcKX7nKlRsvTrDzPbpOi+pG2XPbVuUy5hy4DBGeJsAvDHrZSReP2a/r06x8zKz/hX70khB5rXP0Xb8oHeu226Sxm74rqWyEpV9WnWPmAZLIHfo5MkvVvokxoXIZDR5DdsTUxJSbKyfcOXGy9OsfMxVtemaWLasSwAcwLMrdYrLjsNANkU4Z6ivr06x8zSpaZVOhfTbhXZTUCYW+HuMJdwUn6dOsfM1RG7hHdMIHD6yyr3Kjqh1zhbl/406x8zWlG9xfaB+O2M2rC2P1auFfVp1j5muSLhmYRpHec1HnVwj6cf/8QAIBEAAQQDAQADAQAAAAAAAAAAAQACAxEQEjEhBCIyQf/aAAgBAwEBPwGU01aeWtbTITSMCZ+cP4gL8UMZb6UUFro6sP4hGW+hMftgp3oBw/iid4oxQQpfIeB9Qo5S/wAw/iBriZLsiL4ieqEVeH8wOolSDYKMVh/MM/Qx/FHj/8QAHhEAAgICAwEBAAAAAAAAAAAAAAECAxExEBIhMmH/2gAIAQIBAT8BqeJHf8O+Cy1diN2dE/riv6M4L7c+IiSHLtFPivZ3TLYY9Foj4dHHfENlsSyScup8v0phn0vSWOIbGsllLj6QklsiXPOOIb4ehFMnFlnEN8T+WIh9Is4//8QAMRAAAQMCAwcDAwMFAAAAAAAAAQACEQMSECExIkFRYXFywQQTIDJSoSNCgTORscLR/9oACAEBAAY/AlRmZ9vL+6/dp+UJLuab9XNb5n8LJ5dyTWVI104LYabd6lu0InmqlMkgOZmhiK17RYzQnXPAWEnLfhA0UlRktg5xCDatPKYnkhn+nMfwfhQ7POLQVLs5QIxc14yKh27emdMaHZ5wvqlGreWydlNY7UZFbK2KlFx4HJRVpmm5ar3eDimdBjQ7PKEK2oNkoDhITjhd7bLtJhQE5/qWF7RoWuXtzMhNHLGh2eU2tTOY16pten9JzVSnRIteNHKTqpOimIG5fr3U+btFXqMILRdmmsp5ABN6Y0OzyvUUvubI/jCjG4T+EabuODr3PsJydcclbTFP1JduIQ9DQgffCg5uTOmNDs8oOYYcF1z/AAjWfv0V9P62qHZHQrZcvceWl8RTaP8AKucZccyhTutnemjljQ7PODPcbfSGrU2pRMtwqtjYKNN8GN5RfUMlGod5gK6iWtLRq45BN6Y0OzzjdTPUHQqAban2FPdzKtIBHNVPZ/pgwMKjLWm7imdBjQ7PPwpji4K1bWadTDGwREQg2u2J0THEXAHMJvTGh2efhR7sDgHOZTcG8Wz/ALBFjmt9Q+No/t6N/wCpkaRjQ7PPwZduzxzVSSRAkRgztGH/xAAnEAEAAgEDBAEEAwEAAAAAAAABABEhMUFhEFFxoYEgkbHRweHw8f/aAAgBAQABPyGc7GEanNNGIz4itBvMNm17duIzV4uP7ROoJVDXiHVTI0kPbgLyFPvGtSp2p4m1exvSQ0RpXVgPrxG2zoCAKWisw1mcgNUmzfnWWhYDeQbgYMwDiXpjVTXRX2h+JVb30JpeOqQufQtw2FFxGIhLWhuAQlIfRD7TIq7B4RKnVP46+z6Lw86BDi9DtOXi5oBWCJhocxMCN60G7EZsYy2BeNYFHafF1P8AW7dfdxVUF5JY3+LSLhQuV5v+ZTVM6zLyh5Yrh3TCGwVmFN+auHetqmVWrS58Sxtieuvs4LQiA9uUTlAsc7wCsDqF3hiHq9ZxhOyFg6s00HF7QJbA+MIGVCu8zV1p+Ovs4zDOG5X6YCna09SpF128RoM1HiAGoRMyH8B2g2mApIcukq1AvatzUCFeX4macfx193DvNAwKJhquMmCHStF7Qv3o/UO2X1OzHSg+LmswA6t7vETKRY7xDgg5FzeKgeuvu+inWjyYqBxfRNuJ80Foi7d61hgOqNzmW13HB4m6j9v/ABEpplIbG8Suttfx1931adb+0wh3XqfHeAcdyHNywTDAMA/MtDWbJHpuqvTnM/1u3X3f0MmJQs8wC2pK1YeYQztgQWiFobGAHygXZNkVhjr7v6FU4ywX2iFHtFo52jO0QGWd7gJX1a9OY3/5JXUYavx1939DJDFNd+i6IroyUHbCkzHRn+J26f/aAAwDAQACAAMAAAAQ9LEqjp8/5cS6f86chDRR8pKkOAl89+XBDz89mirc789iABdj8//EAB4RAQACAgIDAQAAAAAAAAAAAAEAESExEEEgUXGh/9oACAEDAQE/EAsZZVtQboYWq0Qi2LE9Lyu6RWiGzENbmZ03xvjQlwMPUpu+ocNsYBylcdkZF7bmYvUdVlmtGjkVXBYuGMMqY12yyx4A2OA7OyWl8D9EZt/GduP/xAAgEQEAAgMBAAEFAAAAAAAAAAABABEQITFBcSCBocHh/9oACAECAQE/EABZQapEG6I+z2cO0PXiGLgqPSALedit3FvWWOMdR+IzfDEcdiUITb8K50uz1hBcqvvAUItC5+/5KUdxzgCmalsiCGyUATRNx9GqUNspHjFdY54/EcFXyTzj/8QAJhABAAIBAwMFAQADAAAAAAAAAQARITFBURBhcYGRocHwsSDR8f/aAAgBAQABPxCa4GgCrvrKwr2sLO7tA643iKbK7TeYZUUbHu8zsJNFoJ6gGNXeVV81rK5qQpiVaOuMepEnHAPOMeQywhQFbHX1GlkvJoB06F8p4WEYAAAK260rhCW3RqxwxWNQCjMhWxAoDVah5hGhqbuZho0Bsf6wznQD+AuJkqgXVrxnzjiDyIUkTIf1EJAXsMveorfkdRM4b/f0wMBRXmC8TNdCsw+9dTBptvKI0EuKMxSTMA0xFOJLTPccJLAu8txNP8ijqmru06l0/wDu6KQ23DO8LkIJYmOdWGKQznSEPZlWLMMsjoNWhNEjl+7XmOQFoVPyJBgswWC3tKw6p3u+k2Gn1OpLP3aJa8YLBYBO5ENTxF1ve1YIDW1B9pSDZRbfvDkqyDTCTvIWZhPW5yyxErTQxbBCqq9XfmVLNYgCqF5Cs9ozy1L0HX1n34AQhNSSweGYeCU3Qunx8wslIWyAARul01oj4ClY1beY20o9i2ArB7im1hofMyjLWlbsFD1qGf32RpZPeANV2Bvz408xqi0696dVXJj98FvwRdUl13s9oMqIVZs2JdKUg6cnuRX3N7qahgRloSghtbQrhygIQkO3MMqyxPa9CN8FV6qx8uvaiFpYQNBrBceEq1+HX8/nGJrYfI8jpUNTiAaJoRugfGSr9ax2ICtZMNe7swjwUeqdr5lzum9D5OIKYMItF30h7i0rU5Vi1xHEAW4vMyRq7mh1/P5dKRhs9J1L3o20d4qu8ClVrNk4lZSAeYmaVUpKLHe8jEnaNUI0BEu5oasooDYbEHQOLsFv5HrCUpeR3uGbwQjSKpu06/n8+hMF1WuDgfZklevM/Lle355Jh4IG8UY+o9KAgIv1DcIbdiGMu6LCsFV3V4jJVNnAjLIq1hzpP0uHX8/n1I56bQpLBYmjMkVw5rDF5CFJpTxF8jqFFYMGPSIocHOYaTfs5zB7yRhpJTjTmIXoNCrGDGOv5/PodL7LFU8N/UyVsmmCBPeYvahVlbkHfVgYUAIYLu9osp6nXmB327BKQtW2IwStqlW89fz+f+ADgAKrGC+2Zkg6EXacRkJa0JkrNIho+SP2n+T8zh0//9k=");
        byte[] inputStreamTwo = Convert.FromBase64String("/9j/4AAQSkZJRgABAQAAAQABAAD/7QCEUGhvdG9zaG9wIDMuMAA4QklNBAQAAAAAAGgcAigAYkZCTUQwYTAwMGE2ZjAxMDAwMGM0MDEwMDAwMmUwMjAwMDA2NjAyMDAwMGEzMDIwMDAwMjMwMzAwMDA5MTAzMDAwMGMxMDMwMDAwZjgwMzAwMDAzNzA0MDAwMGUxMDQwMDAwAP/bAEMABgQFBgUEBgYFBgcHBggKEAoKCQkKFA4PDBAXFBgYFxQWFhodJR8aGyMcFhYgLCAjJicpKikZHy0wLSgwJSgpKP/bAEMBBwcHCggKEwoKEygaFhooKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKCgoKP/CABEIACgAKAMBIgACEQEDEQH/xAAbAAACAgMBAAAAAAAAAAAAAAAABgMFAgQHAf/EABkBAAIDAQAAAAAAAAAAAAAAAAECAAMFBP/aAAwDAQACEAMQAAAB6n7gvAskStvw25iFOP2iXE5doUjapv6aUwqoLMDooMQThdgMfX//xAAfEAACAgIDAAMAAAAAAAAAAAABAwIEAAUREhMQFCL/2gAIAQEAAQUC5+ZsEcAMs5BFjYhU7OymJ13p8UPU8KutTOqr7tzYALdRb2NSx52HTyDJQPqe1Cz4uDCSP2y5rQIRBlOrCAySCqH/xAAdEQEAAgEFAQAAAAAAAAAAAAABAAIRAwQQEyEx/9oACAEDAQE/AQzGicCk7MyxAm6s/Jo3bHs//8QAGxEAAwACAwAAAAAAAAAAAAAAAAECAxEEECL/2gAIAQIBAT8BN9UtjkVF00M5eCYryf/EACQQAAICAQMEAgMAAAAAAAAAAAECABESAyExECJBYRNRFIGx/9oACAEBAAY/Auu8tuJfiECiBB8WAT3zPyNVsd638S9Jw0HewXzvFRnXE9xmolA0d5q47gVXqXtj/egdWII4hzJN+4bFo3M7VqKv2amWi/6aBYRQviBn01w+xuJ//8QAIRABAAICAgICAwAAAAAAAAAAAQARITFBUWFxEJGh0fD/2gAIAQEAAT8hA/OzZ6nCnSYWjtZOUGRc1FjAj3fqYdjk7eO5S3+JQ13gYJFt1WaWuDuH3kP8eoSgNAXEId0MUYR6lizIgZjkli7KuzK9rw68xM2uGqlwOL7MfJx/Vw2bWojZByeo7HQvAezif//aAAwDAQACAAMAAAAQ7s9FEMDiC//EABkRAQEBAQEBAAAAAAAAAAAAAAEAESExof/aAAgBAwEBPxBfMWKWRvLIBi3yJHYDl5m/Z23/xAAZEQEBAQEBAQAAAAAAAAAAAAABEQBRITH/2gAIAQIBAT8QWfcFZrgVyFm55gmd8wOmJ13/xAAiEAEAAgICAgIDAQAAAAAAAAABABEhMUFRYXGBkRChwbH/2gAIAQEAAT8Q1Lnpw/kuh8W4yAtrm++o194hrK8JFpUv/INQBrYCtp4SBK6CLgdlPK7rTFJju+T2OSCLgjhyLOpZfJiD+2rjq2PiKcmhaBeFZ+oILidSZQfXGWoaUDkKYSx3n4JZrj/vs4pyPHiDf6bZR3aubhYhaS1jj9sxkO9Kjm7lmM23oP7CXa8Tfof0hgOYOu5pcIC2ll/MdU7DZQ2Ai8Xk9T//2Q==");


        //using (Image<Rgb24> image = Image.Load(inputStream, out format))
        //{
        //    image.Mutate(c => c.Resize(30, 30));

        //    //image.Save(outputStream, format);
        //}

        // using var image = new Image<Rgba32>(64, 64);
        //using var image = new Image<Rgba32>(64, 64);
        //var ellipse = new EllipsePolygon(32, 32, 70, 70);
        //image.Mutate(x => x.Draw(Color.White, 2f, ellipse));

        using (Image<Rgb24> img1 = Image.Load<Rgb24>(inputStream)) // load up source images
        using (Image<Rgb24> img2 = Image.Load<Rgb24>(inputStreamTwo))
        using (Image<Rgb24> outputImage = new Image<Rgb24>(100, 100)) // create output image of the correct dimensions
        {
            // reduce source images to correct dimensions
            // skip if already correct size
            // if you need to use source images else where use Clone and take the result instead
            img1.Mutate(o => o.Resize(new Size(50, 50)));
            img2.Mutate(o => o.Resize(new Size(50, 50)));

            //var ellipse = new EllipsePolygon(32, 32, 70, 70);
            //img1.Mutate(x => x.Draw(Color.Green, 2f, ellipse));
            EllipsePolygon ellipse = new EllipsePolygon(new PointF(0, 0),  new SizeF(80, 80));
            outputImage.Mutate(x => x.Draw(Color.White, 2f, ellipse));
            // take the 2 source images and draw them onto the image
            outputImage.Mutate(o => o
                    .DrawImage(img1, new Point(50, 0), 1f) // draw the first one top left
                    .DrawImage(img2, new Point(0, 50), 1f) // draw the second next to it
            );

            outputImage.Save("output8.jpg", new JpegEncoder() { Quality = 100 });
        }
    }
}