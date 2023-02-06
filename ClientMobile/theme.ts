import { light } from "@eva-design/eva";

const customColors = {
  "color-violet": "#6e53a6",
  "color-white": "#ffffff",
  "color-black": "#000000",
  "color-blue": "#6b50a5",
  "color-green": "#34c25f",
  "color-check": "#5e4496",
  "color-gray": "#d3d3d3",
  "color-light-gray": "#e5eaef",
}

export const theme = {
  ...customColors,
  ...light,
  "color-primary-100": "#F1D5FA",
  "color-primary-200": "#E0AEF6",
  "color-primary-300": "#C180E4",
  "color-primary-400": "#9D5BCA",
  "color-primary-500": "#6F2DA8",
  "color-primary-600": "#562090",
  "color-primary-700": "#401678",
  "color-primary-800": "#2D0E61",
  "color-primary-900": "#1F0850",
  "color-success-100": "#D6F9CE",
  "color-success-200": "#A8F3A0",
  "color-success-300": "#6BDB6B",
  "color-success-400": "#42B84D",
  "color-success-500": "#14892A",
  "color-success-600": "#0E752B",
  "color-success-700": "#0A622B",
  "color-success-800": "#064F28",
  "color-success-900": "#034126",
  "color-info-100": "#C9FAED",
  "color-info-200": "#95F6E4",
  "color-info-300": "#5EE5D7",
  "color-info-400": "#35CCC9",
  "color-info-500": "#039FAA",
  "color-info-600": "#027C92",
  "color-info-700": "#015E7A",
  "color-info-800": "#004362",
  "color-info-900": "#003151",
  "color-warning-100": "#FDF4CC",
  "color-warning-200": "#FCE79A",
  "color-warning-300": "#F7D366",
  "color-warning-400": "#EFBE40",
  "color-warning-500": "#E59F06",
  "color-warning-600": "#C48204",
  "color-warning-700": "#A46703",
  "color-warning-800": "#844F01",
  "color-warning-900": "#6D3D01",
  "color-danger-100": "#FCE5D1",
  "color-danger-200": "#FAC5A4",
  "color-danger-300": "#F29B74",
  "color-danger-400": "#E67351",
  "color-danger-500": "#D6391D",
  "color-danger-600": "#B82115",
  "color-danger-700": "#9A0E0F",
  "color-danger-800": "#7C0912",
  "color-danger-900": "#660515"
}

export const mapDarkStyle = [
  {
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#212121"
      }
    ]
  },
  {
    "elementType": "labels.icon",
    "stylers": [
      {
        "visibility": "off"
      }
    ]
  },
  {
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#757575"
      }
    ]
  },
  {
    "elementType": "labels.text.stroke",
    "stylers": [
      {
        "color": "#212121"
      }
    ]
  },
  {
    "featureType": "administrative",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#757575"
      }
    ]
  },
  {
    "featureType": "administrative.country",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#9e9e9e"
      }
    ]
  },
  {
    "featureType": "administrative.land_parcel",
    "stylers": [
      {
        "visibility": "off"
      }
    ]
  },
  {
    "featureType": "administrative.locality",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#bdbdbd"
      }
    ]
  },
  {
    "featureType": "poi",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#757575"
      }
    ]
  },
  {
    "featureType": "poi.park",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#181818"
      }
    ]
  },
  {
    "featureType": "poi.park",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#616161"
      }
    ]
  },
  {
    "featureType": "poi.park",
    "elementType": "labels.text.stroke",
    "stylers": [
      {
        "color": "#1b1b1b"
      }
    ]
  },
  {
    "featureType": "road",
    "elementType": "geometry.fill",
    "stylers": [
      {
        "color": "#2c2c2c"
      }
    ]
  },
  {
    "featureType": "road",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#8a8a8a"
      }
    ]
  },
  {
    "featureType": "road.arterial",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#373737"
      }
    ]
  },
  {
    "featureType": "road.highway",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#3c3c3c"
      }
    ]
  },
  {
    "featureType": "road.highway.controlled_access",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#4e4e4e"
      }
    ]
  },
  {
    "featureType": "road.local",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#616161"
      }
    ]
  },
  {
    "featureType": "transit",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#757575"
      }
    ]
  },
  {
    "featureType": "water",
    "elementType": "geometry",
    "stylers": [
      {
        "color": "#000000"
      }
    ]
  },
  {
    "featureType": "water",
    "elementType": "labels.text.fill",
    "stylers": [
      {
        "color": "#3d3d3d"
      }
    ]
  }
];

export const mapStandardStyle = [
  {
      "featureType": "landscape.natural",
      "elementType": "geometry",
      "stylers": [
          {
              "color": "#dde2e3"
          },
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "poi.park",
      "elementType": "all",
      "stylers": [
          {
              "color": "#c6e8b3"
          },
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "poi.park",
      "elementType": "geometry.fill",
      "stylers": [
          {
              "color": "#c6e8b3"
          },
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road",
      "elementType": "geometry.fill",
      "stylers": [
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road",
      "elementType": "geometry.stroke",
      "stylers": [
          {
              "visibility": "off"
          }
      ]
  },
  {
      "featureType": "road",
      "elementType": "labels",
      "stylers": [
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road",
      "elementType": "labels.text.fill",
      "stylers": [
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road",
      "elementType": "labels.text.stroke",
      "stylers": [
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road.highway",
      "elementType": "geometry.fill",
      "stylers": [
          {
              "color": "#c1d1d6"
          },
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road.highway",
      "elementType": "geometry.stroke",
      "stylers": [
          {
              "color": "#a9b8bd"
          },
          {
              "visibility": "on"
          }
      ]
  },
  {
      "featureType": "road.local",
      "elementType": "all",
      "stylers": [
          {
              "color": "#f8fbfc"
          }
      ]
  },
  {
      "featureType": "road.local",
      "elementType": "labels.text",
      "stylers": [
          {
              "color": "#979a9c"
          },
          {
              "visibility": "on"
          },
          {
              "weight": 0.5
          }
      ]
  },
  {
      "featureType": "road.local",
      "elementType": "labels.text.fill",
      "stylers": [
          {
              "visibility": "on"
          },
          {
              "color": "#827e7e"
          }
      ]
  },
  {
      "featureType": "road.local",
      "elementType": "labels.text.stroke",
      "stylers": [
          {
              "color": "#3b3c3c"
          },
          {
              "visibility": "off"
          }
      ]
  },
  {
      "featureType": "water",
      "elementType": "geometry.fill",
      "stylers": [
          {
              "color": "#a6cbe3"
          },
          {
              "visibility": "on"
          }
      ]
  }
]