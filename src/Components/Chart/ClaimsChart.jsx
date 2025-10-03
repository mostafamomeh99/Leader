import React from "react";
import {
  ResponsiveContainer,
  LineChart,
  Line,
  XAxis,
  YAxis,
  Tooltip,
  Legend,
  CartesianGrid,
} from "recharts";
import styles from "./ClaimsChart.module.css";

const data = [
  { year: 2015, submitted: 20, approved: 15 },
  { year: 2016, submitted: 18, approved: 12 },
  { year: 2017, submitted: 30, approved: 25 },
  { year: 2018, submitted: 40, approved: 35 },
  { year: 2019, submitted: 35, approved: 28 },
  { year: 2020, submitted: 45, approved: 32 },
];

const CustomTooltip = ({ active, payload, label }) => {
  if (active && payload && payload.length) {
    return (
      <div className={styles.tooltip}>
        <div className="fw-bold mb-1">{label}</div>
        {payload.map((p) => (
          <div key={p.dataKey} className="d-flex justify-content-between">
            <span style={{ color: p.color || p.stroke }}>{p.name ?? p.dataKey}</span>
            <span className="fw-bold">{p.value}</span>
          </div>
        ))}
      </div>
    );
  }
  return null;
};

export default function ClaimsChart({ height = 300 }) {
  return (
    <div className={styles.chartBox}>
      <h6 className="mb-3">Claims Over the Years</h6>

      <ResponsiveContainer width="100%" height={height}>
        <LineChart data={data} margin={{ top: 10, right: 12, left: -8, bottom: 0 }}>
          {/* gradients */}
          <defs>
            <linearGradient id="gradSubmitted" x1="0" x2="0" y1="0" y2="1">
              <stop offset="5%" stopColor="#7B5CFA" stopOpacity={0.24} />
              <stop offset="95%" stopColor="#7B5CFA" stopOpacity={0} />
            </linearGradient>
            <linearGradient id="gradApproved" x1="0" x2="0" y1="0" y2="1">
              <stop offset="5%" stopColor="#28C76F" stopOpacity={0.18} />
              <stop offset="95%" stopColor="#28C76F" stopOpacity={0} />
            </linearGradient>
          </defs>

          <CartesianGrid strokeDasharray="3 6" stroke="#f0f0f0" />
          <XAxis dataKey="year" tick={{ fill: "#6E6B7B" }} />
          <YAxis tick={{ fill: "#6E6B7B" }} />
          <Tooltip content={<CustomTooltip />} />
          <Legend verticalAlign="top" height={30} />
          <Line
            name="Submitted"
            type="monotone"
            dataKey="submitted"
            stroke="#7B5CFA"
            strokeWidth={3}
            dot={{ r: 3 }}
            activeDot={{ r: 6 }}
            fill="url(#gradSubmitted)"
            fillOpacity={1}
          />
          <Line
            name="Approved"
            type="monotone"
            dataKey="approved"
            stroke="#28C76F"
            strokeWidth={3}
            dot={{ r: 3 }}
            activeDot={{ r: 6 }}
            fill="url(#gradApproved)"
            fillOpacity={1}
          />
        </LineChart>
      </ResponsiveContainer>
    </div>
  );
}
